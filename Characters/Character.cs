using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Resources;
using Cards;
using Cards.Actions;
using Characters.Classes;
using StatusEffects;
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

		public List<StatusEffect> StatusEffects;

		private Actor ActorLink { get; set; }

		public Character(string name, int maxHP = 100, CharacterClass characterClass = CharacterClass.None) {
			Name = name;
			HP = new Health(maxHP, maxHP);
			this.CharacterClass = characterClass;
			this.StatusEffects = new List<StatusEffect>();
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

		public virtual void SetActorLink(Actor actor) {
			this.ActorLink = actor;
		}

		public virtual void ApplyDamage(int amount) {
			HP.DepleteResource(amount);
			DamageTrigger(amount);
		}

		public virtual void ApplyHealing(int amount) {
			HP.SupplyResource(amount, false);
			HealingTrigger(amount);
		}

		public virtual void DamageTrigger(int amount) {
			if(ActorLink) {
				ActorLink.TriggerDamageTaken(amount);
			}
		}

		public virtual void HealingTrigger(int amount) {
			if(ActorLink) {
				ActorLink.TriggerHealing(amount);
			}
		}

		public virtual void AddStatusEffect(StatusEffect newEffect) {
			Debug.Log($"Status Effect Added: {newEffect.Name} ({newEffect.Count})");
			StatusEffect existing = StatusEffects.Find(x => x.Type == newEffect.Type || x.Name == newEffect.Name);
			if(existing != null) {
				existing.Count += newEffect.Count;
			} else {
				StatusEffects.Add(newEffect);
			}
		}

		public virtual void RemoveStatusEffect(string name, int amount = 0) {
			StatusEffect matching = StatusEffects.Find(x => x.Name == name);
			if(matching != null) {
				RemoveStatusEffect(matching, amount);
			}
		}
		public virtual void RemoveStatusEffect(StatusEffectData effectData, int amount = 0) {
			StatusEffect matching = StatusEffects.Find(x => x.Type == effectData);
			if(matching != null) {
				RemoveStatusEffect(matching, amount);
			}
		}
		public virtual void RemoveStatusEffect(StatusEffect effectToRemove, int amount = 0) {
            Debug.Log($"RemoveStatusEffect {effectToRemove.Name} by {amount}");
            Debug.Log($"RemoveStatusEffect current count{effectToRemove.Count}");
			if(amount == -1) {
				StatusEffects.Remove(effectToRemove);
			} else if(amount == 0) {
				effectToRemove.Count--;
			} else {
				effectToRemove.Count -= amount;
			}
            Debug.Log($"RemoveStatusEffect new count{effectToRemove.Count}");
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

			TriggerStatusEffects(StatusEffectTriggerTiming.OnSourceCast);
		}

		public abstract List<Resource> GetAllResources();

		public virtual void StartTurnTrigger(Actor source, List<Actor> enemies) {
			Debug.Log($"Status Effect Count: {this.StatusEffects.Count}");
			TriggerStatusEffects(StatusEffectTriggerTiming.OnTurnStart);
			CardManager.DrawHand(3);
		}

		public virtual List<QueuedAction> EndTurnTrigger(Actor source, List<Actor> enemies) {
			TriggerStatusEffects(StatusEffectTriggerTiming.OnTurnEnd);
			CardManager.DiscardHand();

			return null;
		}

		public virtual void TriggerStatusEffects(StatusEffectTriggerTiming timing) {
			// for(var i = 0; i < StatusEffects.Count; i++) {
			// 	StatusEffects[i].TriggerWithSelfTarget(this);
			// }
			foreach(var effect in StatusEffects.Where(x => x.Type.Timing == timing)) {
				(new StatusEffect(effect.Name, effect.Type, effect.Count)).TriggerWithSelfTarget(this); //only self for now
			}
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
