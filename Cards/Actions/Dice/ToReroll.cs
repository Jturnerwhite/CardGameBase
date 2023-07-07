using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToReroll : iAction {
        private int RerollAmount { get; set; }

        public ToReroll(int amount) {
            this.RerollAmount = amount;
        }

        public ToReroll(ActionData serializedAction) {
            RerollAmount = Int32.Parse(serializedAction.Value);
        }

        public void execute(List<Character> targets, Character source) {
            DiceWrapper resource = (DiceWrapper)source.GetResource();
            Resource[] Dice = ((DiceWrapper)source.GetResource()).GetSubResources();

            Debug.Log($"ToReroll:{RerollAmount}");
            if(RerollAmount < 0 || RerollAmount >= Dice.Length) {
                resource.RollAll();
            } else {
                for(int i = 0; i < Dice.Length; i++) {
                    if(i+1 <= RerollAmount) {
                        resource.Roll(i);
                    }
                }
            }
        }
    }
}