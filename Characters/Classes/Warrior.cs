using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	public class Warrior : Character {
		public Stamina Stamina;

		public Warrior(string name = "Warrior", int initialHP = 20) : base(name, initialHP) {
			Stamina = new Stamina(10, 10);
		}

		public override Resource GetResource() {
			return Stamina;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.Stamina);
			return resources;
		}

		public override bool CanCastCard(Card card) {
			return Stamina.CanCostBePaid(card.Cost, card.CostCheckType);
		}

		public override void CastCard(Card card, List<Character> targets) {
			if(Stamina.CanCostBePaid(card.Cost)) {
				Stamina.PayCost(card.Cost);
			}
		}

		public override void StartTurnTrigger() {
			Stamina.SupplyResource(10);
		}
	}
}
