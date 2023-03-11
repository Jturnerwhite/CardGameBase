using System.Collections;
using System.Collections.Generic;
using Cards;
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
            if(card.CardType == CardType.Reagent) {
				Reagent newReag = new Reagent(card.Name, card.Description, card.Cost, card.TargetsNeeded);
                this.ThePot.AddReagent(newReag);
            }

            CardManager.CastCard(card);
		}
	}
}
