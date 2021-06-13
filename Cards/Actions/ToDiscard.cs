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
            this.DiscardAmount = amount;
            this.Type = type;
        }

        public void execute(List<Character> targets, Character source) {
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