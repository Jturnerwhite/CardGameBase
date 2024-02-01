using System;
using System.Collections.Generic;
using UnityEngine;
using Cards.Actions;
using Characters;
using Utils;

namespace StatusEffects {
    public class StatusEffect {
        public string Name;
        public StatusEffectData Type;
        public List<iAction> TriggerredActions;

        public int Count;

        public StatusEffect(string Name, StatusEffectData Type, int Count = 0) {
            this.Name = Name;
            this.Type = Type;
            this.Count = Count;
            DeserializeActions();
        }

        private void DeserializeActions() {
            TriggerredActions = new List<iAction>();
            foreach(var actionData in this.Type.Actions) {
                TriggerredActions.Add(ActionFactory.ConstructAction(actionData));
            }
        }

        public void TriggerWithSelfTarget(Character source) {
            TriggerWithTargets(new List<Character>{ source }, source);
        }

        public void TriggerWithTargets(List<Character> targets, Character source) {
            Debug.Log($"Trigger {this.Name} for {this.Count} times");
            for(int i = 0; i < Count; i++) {
                foreach(var action in TriggerredActions) {
                    action.Execute(targets, source);
                }
            }

            // Count--;
            // if(Count <= 0) {
            //     source.RemoveStatusEffect(this);
            // }
        }
    }
}