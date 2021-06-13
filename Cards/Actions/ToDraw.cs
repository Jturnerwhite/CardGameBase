using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ToDraw : iAction {
        public enum DrawType {
            Top,
            Random,
            Bottom
        }
        public enum DrawSource {
            Deck,
            Discard
        }

        private int DrawAmount { get; set; }
        private DrawType Type { get; set; }
        private DrawSource Source { get; set; }

        public ToDraw(int amount = 1, DrawType type = DrawType.Top, DrawSource source = DrawSource.Deck) {
            this.DrawAmount = amount;
            this.Type = type;
            this.Source = source;
        }

        public void execute(List<Character> targets, Character source) {
            if(Type == DrawType.Top) {
                for(int i = 0; i < DrawAmount; i++) {
                    source.CardManager.Draw();
                }
            }
            else if(Type == DrawType.Bottom) {
                for(int i = 0; i < DrawAmount; i++) {
                    source.CardManager.DrawSpecific(source.CardManager.Deck.Count - 1);
                }
            } else if(Type == DrawType.Random) {
                for(int i = 0; i < DrawAmount; i++) {
                    source.CardManager.DrawRandom();
                }
            }
        }
    }
}