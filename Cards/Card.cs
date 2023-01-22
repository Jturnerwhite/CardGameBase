using System.Collections.Generic;
using Cards.Actions;
using Utils;
using UnityEngine;

namespace Cards {
    public abstract class Card {
        public string Name { get; set; }
        public Cost Cost { get; set; }
        public int TargetsNeeded { get; set; }
        public string Description { get; set; }

        public List<int> AdditionalCosts { get; set; }

        public Card(string name, string description, Cost cost, int targetsNeeded) {
            Name = name;
            Description = description;
            Cost = cost;
            TargetsNeeded = targetsNeeded;
        }

        public List<iAction> Actions { get; set; }

    }
}