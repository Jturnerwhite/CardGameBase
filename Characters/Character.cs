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

		public void ApplyDamage(int amount) {
			UnityEngine.Debug.Log(this.Name + " lost " + amount + " health");
			HP.DepleteResource(amount);
		}

		abstract public Resource GetResource();

		abstract public bool CanCastCard(Card card);

		abstract public void CastCard(Card card, List<Character> targets);

		abstract public List<Resource> GetAllResources();
	}
}
