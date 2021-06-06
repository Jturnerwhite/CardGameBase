using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class LowBlow : Card {
        public LowBlow() : base("LowBlow", "Deals 3 to 1 target.", 3, 1, AmountCheckType.BelowOrEqual) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(3));
        }
    }
}