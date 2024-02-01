using System;
using System.Collections.Generic;
using UnityEngine;
using Resources;
using Characters;
using StatusEffects;

namespace Cards.Actions {
    public class ToApplyStatus : iAction {
        private string Name { get; set; }
        private int Amount { get; set; }

        private StatusEffect StatusEffect { get; set; }

        public ToApplyStatus() {
        }

        // value = "name,amount"
        public ToApplyStatus(ActionData serializedAction) {
            string valuesCSV = serializedAction.Value;
            string[] values = valuesCSV.Split(',');

            Name = values[0];
            
            int parsedAmount;
            if(!Int32.TryParse(values[1], out parsedAmount)) {
                parsedAmount = 1;
            }
            Amount = parsedAmount;

            this.StatusEffect = StatusEffects.StatusEffectFactory.GetStatusEffect(Name, Amount);
			Debug.Log($"ToApplyStatus Parsed: {this.StatusEffect.Name} ({this.StatusEffect.Count})");
        }

        public void Execute(List<Character> targets, Character source) {
            foreach(var target in targets) {
                ApplyStatus(target);
            }
        }

        private void ApplyStatus(Character target) {
			Debug.Log($"ToApplyStatus ApplyStatus");
            target.AddStatusEffect(this.StatusEffect);
        }
    }
}