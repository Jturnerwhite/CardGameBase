using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	public class Vanguard : Character {

        private Resource Armor;

		public Vanguard(string name = "Vanguard", int initialHP = 20) : base(name, initialHP, CharacterClass.Vanguard) {
            Armor = new Armor(0 , 10);
		}

		public override void ApplyDamage(int amount) {
            int rolloverDamage = 0;
            
            if(amount > Armor.Amount) {
                rolloverDamage = amount - Armor.Amount; 
            }

            Armor.DepleteResource(amount);
			HP.DepleteResource(rolloverDamage);
		}

		public override Resource GetResource() {
			return Armor;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.Armor);
			return resources;
		}
		
		public override bool CanCastCard(Card card) {
			return Armor.CanCostBePaid(card.Cost.Amount, card.Cost.CheckType);
		}

		public override void CastCard(Card card, List<Character> targets) {
			if(CanCastCard(card)) {
				Armor.PayCost(card.Cost.Amount);
			}
			CardManager.CastCard(card);
		}
	}
}
