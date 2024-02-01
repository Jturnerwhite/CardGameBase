using System;
using System.Collections.Generic;
using UnityEngine;
using Resources;
using Characters;
using StatusEffects;

namespace Cards.Actions {
    public class ToRemoveStatus : iAction {
        private string Name { get; set; }
        private int Amount { get; set; }

        private StatusEffect StatusEffect { get; set; }

        public ToRemoveStatus() {
        }

        // value = "name,amount"
        public ToRemoveStatus(ActionData serializedAction) {
            string valuesCSV = serializedAction.Value;
            string[] values = valuesCSV.Split(',');

            Name = values[0];
            
            int parsedAmount;
            if(!Int32.TryParse(values[1], out parsedAmount)) {
                parsedAmount = 1;
            }
            Amount = parsedAmount;
        }

        public void Execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                ApplyStatus(target);
            }
        }

        private void ApplyStatus(Character target) {
            target.RemoveStatusEffect(this.Name, this.Amount);
        }
    }
}