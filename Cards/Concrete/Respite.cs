using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class Respite : Card {
        public override List<iAction> Actions { get; set; }
        public Respite() : base("Respite", "Restores 15 stamina", 0, 0) {
            Actions = new List<iAction>();
            Actions.Add(new ToRestore(15));
        }
    }
}