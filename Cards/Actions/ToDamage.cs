using System;
using System.Collections.Generic;
using Resources;
using Characters;
using UnityEngine;

namespace Cards.Actions {
    public class ToDamage : iAction {
        private int DamageAmount { get; set; }

        public ToDamage(int amount) {
            DamageAmount = amount;
        }

        public ToDamage(ActionData serializedAction) {
            try {
                DamageAmount = Int32.Parse(serializedAction.Value);
            } catch(Exception e) {
                Debug.Log($"{serializedAction.Type} : {serializedAction.Value}");
            }
        }

        public void execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                target.ApplyDamage(DamageAmount);
            }
        }
    }
}