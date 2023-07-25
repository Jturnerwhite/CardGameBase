using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cards;
using Cards.Actions;
using Characters;
using Resources;
using UnityEngine;

namespace Characters.Classes {
	public class Potentate : Character {
        public ThePot ThePot;

		public Potentate(string name = "The Potentate", int initialHP = 40) : base(name, initialHP, CharacterClass.Potentate) {
            ThePot = new ThePot(0, 3);
		}

		public override Resource GetResource() {
			return ThePot;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.ThePot);
			return resources;
		}
		
		public override bool CanCastCard(Card card) {
			return ThePot.CanCostBePaid(card.Cost.Amount);
		}

		public override void CastCard(Card card, List<Character> targets) {
            CardManager.CastCard(card);
		}

		private List<Actor> GetTargets(List<Actor> enemies) {
			List<Actor> actualTargets = new List<Actor>();
			switch(ThePot.Target) {
				default:
					actualTargets.Add(enemies[0]);
					break;
			}

			return actualTargets;
		}

		public override List<QueuedAction> EndTurnTrigger(Actor source, List<Actor> enemies) {
			List<QueuedAction> brewedActions = Brew(source, enemies);
			CardManager.DiscardHand();

			return brewedActions;
		}
	
		public List<QueuedAction> Brew(Actor source, List<Actor> enemies) {
			Card newBrewedCard = ThePot.Brew();
			List<Actor> targets = ThePot.GetTargets(source, enemies);
			List<QueuedAction> queuedActions = new List<QueuedAction>();
			foreach(var action in newBrewedCard.Actions) {
				queuedActions.Add(new QueuedAction("Brewed Actions", source.characterStats, targets.Select(x => x.characterStats).ToList(), action));
			}
			//source.ActionManager.CastCard(ThePot.BrewedCard, source, targets);
			ThePot.Reset();

			return queuedActions;
		}

	}
}
