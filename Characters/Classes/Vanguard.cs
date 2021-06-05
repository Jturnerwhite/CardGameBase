using System.Collections;
using System.Collections.Generic;
using Cards;
using Characters;
using Resources;

namespace Characters.Classes {
	public class Vanguard : Character {

        private Resource Armor;

		public Vanguard(string name = "Vanguard", int initialHP = 100) : base(name, initialHP) {
            Armor = new Armor(0 , 10);
		}

		public override void ApplyDamage(int amount) {
			UnityEngine.Debug.Log(this.Name + " has incoming " + amount + " damage");
            int rolloverDamage = 0;
            
			UnityEngine.Debug.Log(this.Name + " has " + Armor.Amount + " Armor");

            if(amount > Armor.Amount) {
                rolloverDamage = amount - Armor.Amount; 
            }

            Armor.DepleteResource(amount);
			HP.DepleteResource(rolloverDamage);
			UnityEngine.Debug.Log(this.Name + " lost " + amount + " Armor");
			UnityEngine.Debug.Log(this.Name + " lost " + rolloverDamage + " HP");
		}

		public override Resource GetResource() {
			return Armor;
		}

		public override List<Resource> GetAllResources() {
			List<Resource> resources = new List<Resource>();
			resources.Add(this.HP);
			resources.Add(this.Armor);
			return resources;
		}
		
		public override bool CanCastCard(Card card) {
			return Armor.CanCostBePaid(card.Cost);
		}

		public override void CastCard(Card card, List<Character> targets) {
			UnityEngine.Debug.Log(this.Name + " casts " + card.Name + ", using " + card.Cost + " " + Armor.Name);
			if(CanCastCard(card)) {
				Armor.PayCost(card.Cost);
			}
		}
	}
}
