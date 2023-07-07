using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToDiscard : iAction {
        public enum DiscardType {
            First,
            Random,
            Last
        }

        private int DiscardAmount { get; set; }
        private DiscardType Type { get; set; }

        public ToDiscard(int amount = 1, DiscardType type = DiscardType.Random) {
            DiscardAmount = amount;
            Type = type;
        }

        public ToDiscard(ActionData serializedAction) {
            string valuesCSV = serializedAction.Value;
            string[] values = valuesCSV.Split(',');

            int parsedValue;
            if(!Int32.TryParse(values[0], out parsedValue)) {
                parsedValue = 1;
            }
            DiscardAmount = parsedValue;

            DiscardType parsedType = DiscardType.Random;
            if(values.Length > 1) {
                parsedType = Enum.Parse<DiscardType>(values[1], true);
            }

            Type = parsedType;
        }

        public void execute(List<Character> targets, Character source) {
            if(DiscardAmount == -1) {
                source.CardManager.DiscardHand();
            }
            if(Type == DiscardType.First) {
                for(int i = 0; i < DiscardAmount; i++) {
                    source.CardManager.DiscardFromHand(0);
                }
            }
            else if(Type == DiscardType.Last) {
                for(int i = 0; i < DiscardAmount; i++) {
                    source.CardManager.DiscardFromHand(source.CardManager.Hand.Count - 1);
                }
            } else if(Type == DiscardType.Random) {
                for(int i = 0; i < DiscardAmount; i++) {
                    source.CardManager.DiscardRandom();
                }
            }
        }
    }
}