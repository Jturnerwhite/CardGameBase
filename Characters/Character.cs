using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;
using Cards;
using Characters.Classes;

namespace Characters {
	public abstract class Character {

		public string Name { get; set; }

		public Health HP { get; set; }

		public CharacterClass characterClass { get; set; }

		public Character(string name, int maxHP = 100) {
			Name = name;
			HP = new Health(maxHP, maxHP);
		}

		public virtual void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
		}

		public abstract Resource GetResource();

		public abstract bool CanCastCard(Card card);

		public abstract void CastCard(Card card, List<Character> targets);

		public abstract List<Resource> GetAllResources();

		public virtual void StartTurnTrigger() {

		}

		public virtual void EndTurnTrigger() {
			
		}
	}
}
