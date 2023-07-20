using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public Card BrewedCard = null;

        public ThePot(int amount = 0, int maxAmount = 3) : base(amount, maxAmount, "The Pot", ResourceType.ThePot, Color.red) {
            Contents = new List<Reagent>();
        }

        public List<Reagent> GetContents() {
            return Contents;
        }

        public void SetTargetType(TargetType target) {
            Target = target;
        }

        public void AddReagent(string name, IEnumerable<Tuple<SubActionData, iAction>> actions) {
            Reagent newReagent = new Reagent() {
                Name = name,
                Pieces = new List<ReagentPiece>()
            };
            newReagent.Pieces.AddRange(actions.Select(x => new ReagentPiece(){ Origin = x.Item1, Action = x.Item2}));

            Contents.Add(newReagent);
            Amount++;

            Debug.Log($"Reagent Added: {name}");
        }

        public void RemoveReagent(int index = -1) {
            if(index < 0) {
                index = Contents.Count - 1;
            }

            Contents.RemoveAt(index);
            Amount--;
        }

        // depletion here represents... something?
        public override void DepleteResource(int depletion)
        {
            if(depletion > Amount) {
                Contents = new List<Reagent>();
                Amount = 0;
            } else {
                for(int i = depletion; i > 0; i--) {
                    RemoveReagent(Contents.Count - i);
                }
            }
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
            Card brewedCard = new Card("", "", new Cost(0), 0);
            brewedCard.CardType = CardType.Virtual;
            brewedCard.Actions = new List<iAction>();
            // start list of all catalysts

            foreach(var reagent in Contents) {
                brewedCard.Name += reagent.Name;
                foreach(var reagentPiece in reagent.Pieces) {
                    // if the type of action is one that modifies all others, handle here
                    if(false) {
                        // add to list of catalysts
                    } else if(reagentPiece.Origin.Type == ActionType.ChangeTarget) {
                        SetTargetType(((ChangeTarget)reagentPiece.Action).Target);
                    } else {
                        brewedCard.Actions.Add(reagentPiece.Action);
                    }
                }
            }

            // apply catalysts

            BrewedCard = brewedCard;
        }

		public List<Actor> GetTargets(Actor source, List<Actor> enemies) {
			List<Actor> actualTargets = new List<Actor>();
			switch(Target) {
				default:
					actualTargets.Add(enemies[0]);
					break;
			}

			return actualTargets;
		}

        private void ApplyCatalysts() {
            // TODO
        }

        public void Reset() {
            Contents = new List<Reagent>();
            Target = TargetType.RandomEnemy;
            Amount = 0;
        }
    }
}