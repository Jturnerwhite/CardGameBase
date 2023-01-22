using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;
using Cards.Actions;
using System;

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
                output.Actions.Add(ConstructAction(serializedAction));
            }
            return output;
        }

        public static iAction ConstructAction(ActionData serializedAction) {
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
                default:
                    return new ToRestore(0);
            }
        }

        // public static List<Card> GetDeck(CharacterClass type) {
        //     DeckData[] decksLoaded = UnityEngine.Resources.LoadAll<DeckData>("Scriptables/DefaultDecks");
        //     Debug.Log($"Decks Loaded: {decksLoaded.Length}");

        //     switch(type) {
        //         case CharacterClass.Zealot:
        //             return GetZealotDeck();
        //         case CharacterClass.Warrior:
        //             return GetWarriorDeck();
        //         case CharacterClass.Vanguard:
        //             return GetVanguardDeck();
        //         case CharacterClass.Gambler:
        //             return GetGamblerDeck();
        //         default:
        //             return GetWarriorDeck();
        //     }
        // }

        // public static List<Card> GetWarriorDeck() {
        //     List<Card> deck = new List<Card>();
        //     deck.Add(new Strike());
        //     deck.Add(new HorizonStrike());
        //     deck.Add(new HorizonStrike());
        //     deck.Add(new Strike());
        //     deck.Add(new Strike());
        //     deck.Add(new Rummage());
        //     deck.Add(new Rummage());
        //     deck.Add(new Rummage());
        //     deck.Add(new Rummage());
        //     return deck;
        // }
        
        // public static List<Card> GetZealotDeck() {
        //     List<Card> deck = new List<Card>();
        //     deck.Add(new Strike());
        //     deck.Add(new Strike());
        //     deck.Add(new Strike());
        //     deck.Add(new Strike());
        //     deck.Add(new Strike());
        //     return deck;
        // }
        
        // public static List<Card> GetVanguardDeck() {
        //     List<Card> deck = new List<Card>();
        //     deck.Add(new ScrapSlap());
        //     deck.Add(new ScrapSlap());
        //     deck.Add(new ArmorUp());
        //     deck.Add(new ArmorUp());
        //     deck.Add(new ArmorUp());
        //     return deck;
        // }
        
        // public static List<Card> GetGamblerDeck() {
        //     List<Card> deck = new List<Card>();
        //     deck.Add(new Jackpot());
        //     deck.Add(new SnakeEye());
        //     deck.Add(new LowBlow());
        //     deck.Add(new LowBlow());
        //     deck.Add(new LowBlow());
        //     deck.Add(new HighRoller());
        //     deck.Add(new HighRoller());
        //     return deck;
        // }
    }
}