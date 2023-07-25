using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToRestore : iAction {
        private int RestoreAmount { get; set; }

        public ToRestore(int amount) {
            this.RestoreAmount = amount;
        }

        public ToRestore(ActionData serializedAction) {
            RestoreAmount = Int32.Parse(serializedAction.Value);
        }

        public void Execute(List<Character> targets, Character source) {
            Resource resource = source.GetResource();
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