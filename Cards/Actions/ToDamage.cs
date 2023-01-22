using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToDamage : iAction {
        private int DamageAmount { get; set; }

        public ToDamage(int amount) {
            DamageAmount = amount;
        }

        public ToDamage(ActionData serializedAction) {
            DamageAmount = Int32.Parse(serializedAction.Value);
        }

        public void execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                target.ApplyDamage(DamageAmount);
            }
        }
    }
}