using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class Rummage : Card {
        public Rummage() : base("Rummage", "Discard a card at random, Draw a card.", new Cost(4), 0) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDiscard(1));
            Actions.Add(new ToDraw(1));
        }
    }
}