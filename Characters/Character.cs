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

		public CardManager CardManager { get; set; }
		public CharacterClass characterClass { get; set; }

		public Character(string name) {
			Name = name;
			HP = new Health(100, 100);

			CardManager = new CardManager();
			CardManager.Deck = CardFactory.GetDeck(characterClass);
			CardManager.DrawHand();
		}

		public void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
		}

		abstract public Resource GetResource();

		abstract public bool CanCastCard(Card card);

		abstract public void CastCard(Card card, List<Character> targets);

		abstract public List<Resource> GetAllResources();
	}
}
