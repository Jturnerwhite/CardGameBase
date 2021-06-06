using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class ViciousVigor : Card {
        public ViciousVigor() : base("Vicious Vigor", "Deal 18 damage, 28 if below 50% HP", 28, 1) {
           
            Actions = new List<iAction>();
            Actions.Add(new ToDamageWithThreshold(18, 50, true, AmountCheckType.BelowNotEqual, 28));
        }
    }
}