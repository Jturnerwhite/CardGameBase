using System.Collections.Generic;
using Cards.Actions;

namespace Cards {
    public abstract class Card {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int TargetsNeeded { get; set; }
        public string Description { get; set; }

        public Card(string name, string description, int cost, int targetsNeeded) {
            Name = name;
            Description = description;
            Cost = cost;
            TargetsNeeded = targetsNeeded;
        }

        public abstract List<iAction> Actions { get; set; }
    }
}