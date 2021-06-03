using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes 
{
	public class Warrior : Character 
	{
		public Stamina Stamina;

		public Warrior() : base("Warrior") {
			Stamina = new Stamina(100, 100);
		}

		public override Resource GetResource() {
			return Stamina;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.HP);
			resources.Add(this.Stamina);
			return resources;
		}

		public override bool CanCastCard(Card card) {
			return Stamina.CanCostBePaid(card.Cost);
		}

		public override void CastCard(Card card, List<Character> targets) {
			UnityEngine.Debug.Log(this.Name + " casts " + card.Name + ", using " + card.Cost + " " + Stamina.Name);
			if(Stamina.CanCostBePaid(card.Cost)) {
				Stamina.PayCost(card.Cost);
			}
		}
	}
}
