using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToDamage : iAction {
        private int DamageAmount { get; set; }

        public ToDamage(int amount) {
            this.DamageAmount = amount;
        }

        public void execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                target.ApplyDamage(DamageAmount);
            }
        }
    }
}