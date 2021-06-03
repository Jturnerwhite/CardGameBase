using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToDamageWithThreshold : iAction {
        private int DamageAmount { get; set; }
        private int Threshold { get; set; }
        private bool IsPercent { get; set; }
        private bool Above { get; set; }
        private bool Equal { get; set; }

        // Optional - If provided, the threshold check will add this to the current resource
        // Used for "Check before cast amount" threshold checks
        // Otherwise, the threshold check will always be comparing a resource "post-cast" of this card
        private int Adjustment { get; set; }


        public ToDamageWithThreshold(int amount, int threshold, bool isPercent, bool above, bool equal, int adjustment = 0) {
            DamageAmount = amount;
            Threshold = threshold;
            IsPercent = isPercent;
            Above = above;
            Equal = equal;
            Adjustment = adjustment;
        }

        public void execute(List<Character> targets, Character source) {
            Resource resource = source.GetResource();

            if(resource.MeetsThreshold(Threshold, IsPercent, Above, Equal, Adjustment)) {
                foreach(var target in targets) {
                    target.ApplyDamage(DamageAmount);
                }
            }
        }
    }
}