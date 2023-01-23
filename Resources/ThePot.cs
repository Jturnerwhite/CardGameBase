using System.Collections;
using System.Collections.Generic;
using Cards;
using Cards.Actions;
using UnityEngine;
using Utils;

namespace Resources {
    // Amount represents "current number of items in The Pot"
    // MaxAmount represents "maximum number of items allowed in The Pot"
    public class ThePot : Resource {
        public TargetType Target;
        public List<Reagent> PotContents;

        public ThePot(int amount, int maxAmount) : base(amount, maxAmount, "The Pot", ResourceType.ThePot, Color.red) {

        }

        public void SetTarget(TargetType target) {
            Target = target;
        }

        public void AddReagent(Reagent card) {
            PotContents.Add(card);
        }

        public void RemoveReagent(int index = -1) {
            PotContents.RemoveAt(index);
        }

        // depletion here represents... something?
        public override void DepleteResource(int depletion)
        {
            List<Card>
            PotContents = new List<Card>();
        }

        // is there space in The Pot?
        public override bool CanCostBePaid(int cost, AmountCheckType checkType = AmountCheckType.AboveOrEqual, int adjustment = 0)
        {
            return (Amount + cost <= MaxAmount);
        }

        public override void PayCost(int cost, AmountCheckType checkType = AmountCheckType.AboveOrEqual, int adjustment = 0) {
			DepleteResource(cost);
		}

        public void Brew() {

        }
    }
}