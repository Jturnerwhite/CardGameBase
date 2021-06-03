using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class Strike : Card {
        public override List<iAction> Actions { get; set; }
        public Strike() : base("Strike", "Deal 6 damage to 1 target", 10, 1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(6));
        }
    }
}