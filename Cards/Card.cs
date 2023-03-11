using System.Collections.Generic;
using Cards.Actions;
using Utils;
using UnityEngine;

namespace Cards {
    public class Card {

        public string Name;
        public CardType CardType = CardType.Default;
        public int TargetsNeeded;
        public string Description;

        public Cost Cost { get; set; }
        public List<iAction> Actions { get; set; }
        public List<Cost> AdditionalCosts;

        public Card(string name, string description, Cost cost, int targetsNeeded, CardType type = CardType.Default) {
            Name = name;
            Description = description;
            Cost = cost;
            TargetsNeeded = targetsNeeded;
        }

        public Card(CardData baseData) {
            Name = baseData.Name;
            Description = baseData.Description;
            TargetsNeeded = baseData.TargetsNeeded;
            this.CardType = baseData.CardType;
            SetCost(baseData.Cost);
            SetAdditionalCosts(baseData.AdditionalCosts);

            Debug.Log($"Card Created {Name} : Cost: {Cost.Amount}");
        }

        public void SetCost(CostData costData) {
            Cost = new Cost(costData);
        }

        public void SetAdditionalCosts(List<CostData> costData) {
            List<Cost> newAddCosts = new List<Cost>();
            foreach(var cost in costData) {
                newAddCosts.Add(cost as Cost);
            }

            AdditionalCosts = newAddCosts;
        }
    }
}