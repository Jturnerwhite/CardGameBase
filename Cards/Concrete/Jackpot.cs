using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class Jackpot : Card {
        public Jackpot() : base("Jackpot!", "Deal 12 damage to 1 target", 6, 1, AmountCheckType.Exact) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(12));
        }
    }
}