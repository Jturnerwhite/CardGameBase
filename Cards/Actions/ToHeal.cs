using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToHeal : iAction {
        private int RestoreAmount { get; set; }

        public ToHeal(int amount) {
            this.RestoreAmount = amount;
        }

        public ToHeal(ActionData serializedAction) {
            RestoreAmount = Int32.Parse(serializedAction.Value);
        }

        public void execute(List<Character> targets, Character source) {
            Resource resource = source.HP;
            int maxAmount = resource.GetMaxAmount();
            int currentAmount = resource.GetAmount();

            // move overflow logic to the Resource
            if (currentAmount + RestoreAmount <= maxAmount) {
                resource.SupplyResource(RestoreAmount);
            } else {
                resource.SetAmount(maxAmount);
            }
        }
    }
}