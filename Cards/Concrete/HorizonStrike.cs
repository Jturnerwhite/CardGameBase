using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class HorizonStrike : Card {
        public HorizonStrike() : base("Horizon Strike", "Deal 5 damage to all targets", new Cost(6), -1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(5));
        }
    }
}