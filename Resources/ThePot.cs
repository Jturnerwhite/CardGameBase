using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Cards.Actions;
using Characters;
using UnityEngine;
using Utils;

namespace Resources {
    public class ThePot : Resource {

        // Amount represents "current number of items in The Pot"

        // MaxAmount represents "maximum number of items allowed in The Pot"

        public TargetType Target;
        public List<Reagent> Contents;

        public ThePot(int amount = 0, int maxAmount = 3) : base(amount, maxAmount, "The Pot", ResourceType.ThePot, Color.red) {
            Contents = new List<Reagent>();
        }

        public void SetTarget(TargetType target) {
            Target = target;
        }

        public void AddReagent(Reagent reagent) {
            Contents.Add(reagent);
            Amount++;

            Debug.Log($"Reagent Added: {reagent.Name}");
        }

        public void RemoveReagent(int index = -1) {
            Contents.RemoveAt(index);
        }

        // depletion here represents... something?
        public override void DepleteResource(int depletion)
        {
            List<Reagent> PotContents = new List<Reagent>();
        }

        // is there space in The Pot?
        public override bool CanCostBePaid(int cost, AmountCheckType checkType = AmountCheckType.AboveOrEqual, int adjustment = 0)
        {
            return (Amount + cost <= MaxAmount);
        }

        public override void PayCost(int cost, AmountCheckType checkType = AmountCheckType.AboveOrEqual, int adjustment = 0) {
			DepleteResource(cost);
		}

        public void Brew(List<Character> potentialTargets, Character source) {
            // determine targets
            List<Character> actualTargets = CharacterFactory.GetTargets(potentialTargets, source, Target);

            // make list of all effects and their original Reagent
            List<Tuple<ReagentAction, Reagent>> actionList = ColateReagentActions();

            // Apply all catalysts (TODO: Add catalysts)

            int heals = 0;
            int damages = 0;

            // go through all actions, totalling effects
            foreach(var action in actionList) {
                switch(action.Item1.Type) {
                    case ReagentType.Heal:
                    heals += action.Item1.Amount;
                        break;
                    case ReagentType.Damage:
                    damages += action.Item1.Amount;
                        break;
                }
            }
        }

        private List<Tuple<ReagentAction, Reagent>> ColateReagentActions() {
            // make list of all effects and their original Reagent
            List<Tuple<ReagentAction, Reagent>> actionList = new List<Tuple<ReagentAction, Reagent>>();
            foreach(Reagent reagent in Contents) {
                foreach(ReagentAction reagentAction in reagent.ReagentActions) {
                    actionList.Add(Tuple.Create(reagentAction, reagent));
                }
            }

            return actionList;
        }
    
        private void ApplyCatalysts() {
            // TODO
        }
    }
}