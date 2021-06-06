using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class ScrapSlap : Card {
        public ScrapSlap() : base("Scrap Slap", "Deal 5 damage to 1 target", 5, 1) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(5));
        }
    }
}