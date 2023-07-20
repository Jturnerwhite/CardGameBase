using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;
using Cards;
using Characters.Classes;
using Saves;
using System;

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

		public virtual void SetFromSave(CharacterSaveData data) {
			Name = data.Name;
			HP = new Health(data.CurrentHP, data.MaxHP);
			CharacterClass = data.CharacterClass;
			SetResource(data.ResourceData);
		}

		public virtual void SetCardManager(List<CardData> cardData) {
			CardManager.Init(CardFactory.ConstructDeck(cardData));
		}

		public virtual void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
		}

		public virtual void SetDeck(List<Card> startingDeck) {
			
		}

		public virtual void SetResource(ResourceSaveData saveData) {
			Resource resource = GetResource();
			resource.SetAmount(saveData.MinOrCurrent);
			resource.SetMaxAmount(saveData.Max);
		}

		public abstract Resource GetResource();

		public abstract bool CanCastCard(Card card);

		public virtual void CastCard(Card card, List<Character> targets) {
			CardManager.CastCard(card);
		}

		public abstract List<Resource> GetAllResources();

		public virtual void StartTurnTrigger(Actor source, List<Actor> enemies) {
			CardManager.DrawHand(3);
		}

		public virtual void EndTurnTrigger(Actor source, List<Actor> enemies) {
			CardManager.DiscardHand();
		}

		public virtual CharacterSaveData GetCharacterSaveData() {
			CharacterSaveData charData = new CharacterSaveData();
			charData.Name = this.Name;
			charData.CharacterClass = this.CharacterClass;
			charData.CurrentHP = this.HP.Amount;
			charData.MaxHP = this.HP.MaxAmount;
			charData.ResourceData = this.GetResource().GetResourceSaveData();

			return charData;
		}
	}
}
