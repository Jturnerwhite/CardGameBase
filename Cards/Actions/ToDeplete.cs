using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToDeplete : iAction {
        private int DepleteAmount { get; set; }

        public ToDeplete(int amount) {
            this.DepleteAmount = amount;
        }

        public ToDeplete(ActionData serializedAction) {
            DepleteAmount = Int32.Parse(serializedAction.Value);
        }

        public void execute(List<Character> targets, Character source) {
            Resource resource = source.GetResource();
            int maxAmount = resource.GetMaxAmount();
            int currentAmount = resource.GetAmount();

            // move overflow logic to the Resource
            if (currentAmount - DepleteAmount > 0) {
                resource.DepleteResource(DepleteAmount);
            } else {
                resource.SetAmount(0);
            }
        }
    }
}