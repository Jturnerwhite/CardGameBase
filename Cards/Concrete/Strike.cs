using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class Strike : Card {
        public Strike() : base("Strike", "Deal 6 damage to 1 target", new Cost(5), 1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(6));
        }
    }
}