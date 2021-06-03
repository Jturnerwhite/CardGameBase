using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class ViciousVigor : Card {
        public override List<iAction> Actions { get; set; }
        public ViciousVigor() : base("Vicious Vigor", "Deal 18 damage, 28 if on low life", 28, 1) {
           
            Actions = new List<iAction>();
            Actions.Add(new ToDamageWithThreshold(18, 50, true, false, true, 28));
        }
    }
}