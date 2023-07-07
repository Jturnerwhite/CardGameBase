using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;
using Cards.Actions;
using System;
using Saves;

namespace Cards 
{
    public static class CardFactory 
    {
        public static List<Card> GetDeck(CharacterClass type, bool defaultDeck = true) {
            return ConstructDeck(GetDeckData(type));
        }

        public static DeckData GetDeckData(CharacterClass type) {
            DeckData[] decksLoaded = UnityEngine.Resources.LoadAll<DeckData>("Scriptables/DefaultDecks");

            Debug.Log($"Decks Loaded: {decksLoaded.Length}");

            if(decksLoaded.Length == 0) {
                Debug.Log($"No default DeckData found for CharacterClass[{type}]");
                return null;
            }

            foreach(var deck in decksLoaded) {
                if(deck.AssignedClass == type) {
                    return deck;
                }
            }

            return decksLoaded[0];
        }

        public static List<Card> ConstructDeck(List<CardData> serializedDeck) {
            List<Card> instCards = new List<Card>();
            foreach(var serializedCard in serializedDeck) {
                instCards.Add(ConstructCard(serializedCard));
            }
            return instCards;
        }

        public static List<Card> ConstructDeck(DeckData serializedDeck) {
            List<Card> instCards = new List<Card>();
            foreach(var serializedCard in serializedDeck.Cards) {
                instCards.Add(ConstructCard(serializedCard));
            }
            return instCards;
        }

        public static Card ConstructCard(CardData serializedCard) {
            Card output = new Card(serializedCard);
            output.Actions = new List<iAction>();
            foreach(var serializedAction in serializedCard.Actions) {
                output.Actions.Add(ConstructAction(serializedAction, output));
            }
            return output;
        }

        public static iAction ConstructAction(ActionData serializedAction, Card card = null) {
            switch(serializedAction.Type) {
                case ActionType.ToDamage:
                    return new ToDamage(serializedAction);
                case ActionType.ToDamageWithThreshold:
                    return new ToDamageWithThreshold(serializedAction);
                case ActionType.ToDiscard:
                    return new ToDiscard(serializedAction);
                case ActionType.ToDraw:
                    return new ToDraw(serializedAction);
                case ActionType.ToRestore:
                    return new ToRestore(serializedAction);
                case ActionType.ReagentAction:
                    return new ReagentAction(serializedAction);
                case ActionType.ChangeTarget:
                    return new ChangeTarget(serializedAction);
                case ActionType.Brew:
                    return new Brew();
                case ActionType.ToDeplete:
                    return new ToDeplete(serializedAction);
                case ActionType.ToReroll:
                    return new ToReroll(serializedAction);
                default:
                    return new ToRestore(0);
            }
        }
    }
}