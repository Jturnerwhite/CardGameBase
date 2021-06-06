using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class HighRoller : Card {
        public HighRoller() : base("HighRoller", "Deals 6 to 1 target.", 3, 1, AmountCheckType.AboveNotEqual) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(6));
        }
    }
}