using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Enemies {
	public class Basic : Character {
		public Basic(string name) : base(name, 50) {
		}

		public override Resource GetResource() {
			return null;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.HP);
			return resources;
		}

		public override bool CanCastCard(Card card) {
			return true;
		}

		public override void CastCard(Card card, List<Character> targets) {
			// No costs being paid
		}
	}
}