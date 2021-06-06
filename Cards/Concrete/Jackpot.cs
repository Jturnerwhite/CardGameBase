using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class Jackpot : Card {
        public Jackpot() : base("Jackpot!", "Deal 12 damage to 1 target", new Cost(6, AmountCheckType.Exact), 1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(12));
        }
    }
}