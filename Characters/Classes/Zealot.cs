using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;
using StatusEffects;

namespace Characters.Classes {
	public class Zealot : Character {

		public Zealot(string name = "Zealot", int initialHP = 40) : base(name, initialHP, CharacterClass.Zealot) {
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
			return HP.CanCostBePaid(card.Cost.Amount, card.Cost.AmountCheckType);
		}

		public override void CastCard(Card card, List<Character> targets) {
			if(CanCastCard(card)) {
				HP.PayCost(card.Cost.Amount);
			}

			base.CastCard(card, targets);
		}

        public override void StartTurnTrigger(Actor source, List<Actor> enemies)
        {
			this.AddStatusEffect(StatusEffectFactory.GetStatusEffect("Regen", 1));
            base.StartTurnTrigger(source, enemies);
        }
    
	}
}
