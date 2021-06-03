using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class HorizonStrike : Card {
        public override List<iAction> Actions { get; set; }
        public HorizonStrike() : base("Horizon Strike", "Deal 5 damage to all targets", 10, -1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(5));
        }
    }
}