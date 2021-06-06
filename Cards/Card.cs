using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public abstract class Card {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int TargetsNeeded { get; set; }
        public string Description { get; set; }
        public AmountCheckType CostCheckType { get; set; }

        public Card(string name, string description, int cost, int targetsNeeded, AmountCheckType checkType = AmountCheckType.AboveOrEqual) {
            Name = name;
            Description = description;
            Cost = cost;
            TargetsNeeded = targetsNeeded;
            CostCheckType = checkType;
        }

        public List<iAction> Actions { get; set; }
    }
}