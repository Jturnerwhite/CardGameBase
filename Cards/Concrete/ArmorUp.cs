using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public class ArmorUp : Card {
        public ArmorUp() : base("ArmorUp", "Add 5 armor", 0, 0) {
            
            Actions = new List<iAction>();
            Actions.Add(new ToRestore(5));
        }
    }
}