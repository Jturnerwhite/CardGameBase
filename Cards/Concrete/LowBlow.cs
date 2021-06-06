using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class LowBlow : Card {
        public LowBlow() : base("LowBlow", "Deals 3 to 1 target.", new Cost(4, AmountCheckType.BelowNotEqual), 1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(3));
        }
    }
}