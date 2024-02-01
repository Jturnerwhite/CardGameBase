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

        public void Execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                ExecuteHeal(target);
            }
        }

        private void ExecuteHeal(Character target) {
            target.ApplyHealing(RestoreAmount);
        }
    }
}