using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;
using Cards.Actions;
using System;
using Saves;
using UnityEditor;

namespace Cards 
{
    public static class CardFactory 
    {
        public static List<CardData> BaseCardData;

        public static CardData GetCardData(string name) {
            CardData match;

            if(BaseCardData == null) {
                BaseCardData = new List<CardData>();
            } else {
                match = BaseCardData.Find(x => x.Name == name);
                if(match != null) {
                    return match;
                }
            }

            string[] matchingNames = AssetDatabase.FindAssets(name, new[] { "Assets/Resources/Scriptables/SerializedCards" });
            string path = AssetDatabase.GUIDToAssetPath(matchingNames[0]);
            match = AssetDatabase.LoadAssetAtPath<CardData>(path);
            if(match != null) {
                BaseCardData.Add(match);
                return match;
            }

            return null;
        }

        public static Card GetCard(string name) {
            try {
                CardData match = GetCardData(name);

                if(match) {
                    return ConstructCard(match);
                } else {
                    return null;
                }
            } catch(Exception e) {
                Debug.LogError($"ERROR: CardFactory.GetCard() card not found: {name}");
                Debug.LogError(e.Message);
                return null;
            }
        }

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
                output.Actions.Add(ActionFactory.ConstructAction(serializedAction, output));
            }
            return output;
        }
    }
}