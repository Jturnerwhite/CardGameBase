using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;
using Cards;
using Characters.Classes;

namespace Characters {

	// Represents the Character's Stats, not cards
	// It is however used to determine if cards can be cast, based off its resources.
	public abstract class Character {

		public string Name { get; set; }
		public CharacterClass CharacterClass { get; set; }
		public Health HP { get; set; }

		public CardManager CardManager;

		public Character(string name, int maxHP = 100, CharacterClass characterClass = CharacterClass.None) {
			Name = name;
			HP = new Health(maxHP, maxHP);
			this.CharacterClass = characterClass;
			CardManager = new CardManager();
			CardManager.Init(null);
		}

		public virtual void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
		}

		public virtual void SetDeck(List<Card> startingDeck) {
			
		}

		public abstract Resource GetResource();

		public abstract bool CanCastCard(Card card);

		public virtual void CastCard(Card card, List<Character> targets) {
			CardManager.CastCard(card);
		}

		public abstract List<Resource> GetAllResources();

		public virtual void StartTurnTrigger() {
			CardManager.DrawHand(3);
		}

		public virtual void EndTurnTrigger() {
			CardManager.DiscardHand();
		}
	}
}
