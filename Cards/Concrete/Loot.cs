using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class Loot : Card {
        public Loot() : base("Loot", "Draw a card, Discard a card at random.", new Cost(4), 0) {
            Actions = new List<iAction>();
            Actions.Add(new ToDraw(1));
            Actions.Add(new ToDiscard(1));
        }
    }
}