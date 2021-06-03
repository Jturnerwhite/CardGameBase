using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	public class Zealot : Character {

		//public Stamina Stamina { get; set; }

		public Zealot() : base("Zealot") {
		}

		public override Resource GetResource() {
			return HP;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.HP);
			return resources;
		}
		
		public override bool CanCastCard(Card card) {
			return HP.CanCostBePaid(card.Cost);
		}

		public override void CastCard(Card card, List<Character> targets) {
			UnityEngine.Debug.Log(this.Name + " casts " + card.Name + ", using " + card.Cost + " " + HP.Name);
			if(CanCastCard(card)) {
				HP.PayCost(card.Cost);
			}
		}
	}
}
