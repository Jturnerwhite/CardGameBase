using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	public class Warrior : Character {
		public Stamina Stamina;

		public Warrior(string name = "Warrior", int initialHP = 20) : base(name, initialHP, CharacterClass.Warrior) {
			Stamina = new Stamina(10, 10);
			Stamina.PendingChange = 5;
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
			return Stamina.CanCostBePaid(card.Cost.Amount, card.Cost.AmountCheckType);
		}

		public override void CastCard(Card card, List<Character> targets) {
			if(Stamina.CanCostBePaid(card.Cost.Amount)) {
				Stamina.PayCost(card.Cost.Amount);
			}

			CardManager.CastCard(card);
		}

		public override void StartTurnTrigger() {
			Stamina.SupplyResource(5);
			CardManager.DrawHand(3);
		}
	}
}
