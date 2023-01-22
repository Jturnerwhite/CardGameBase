using System.Collections.Generic;
using Resources;
using Characters;
using Utils;
using System;

namespace Cards.Actions {

    // I'm broken pls fix me
    public class ToDamageWithThreshold : iAction {
        private int DamageAmount { get; set; }
        private int Threshold { get; set; }
        private bool IsPercent { get; set; }
        private AmountCheckType CheckType { get; set; }

        // Optional - If provided, the threshold check will add this to the current resource
        // Used for "Check before cast amount" threshold checks
        // Otherwise, the threshold check will always be comparing a resource "post-cast" of this card
        private int Adjustment { get; set; }

        public ToDamageWithThreshold(int amount, int threshold, bool isPercent, AmountCheckType checkType, int adjustment = 0) {
            DamageAmount = amount;
            Threshold = threshold;
            IsPercent = isPercent;
            CheckType = checkType;
            Adjustment = adjustment;
        }

        public ToDamageWithThreshold(ActionData serializedAction) {
            string valuesCSV = serializedAction.Value;
            string[] values = valuesCSV.Split(',');

            DamageAmount = Int32.Parse(values[0]);
            Threshold = Int32.Parse(values[1]);
            IsPercent = Boolean.Parse(values[2]);

            AmountCheckType parsedCheckType;
            Enum.TryParse<AmountCheckType>(values[3], true, out parsedCheckType);
            CheckType = parsedCheckType;

            int parsedAdj;
            if(!Int32.TryParse(values[4], out parsedAdj)) {
                parsedAdj = 0;
            }
            Adjustment = parsedAdj;
        }

        public void execute(List<Character> targets, Character source) {
            Resource resource = source.GetResource();
            int adjustedValue = (resource.MeetsThreshold(Threshold, IsPercent, CheckType, Adjustment)) ? DamageAmount + Adjustment : DamageAmount;

            foreach(var target in targets) {
                target.ApplyDamage(adjustedValue);
            }
        }
    }
}