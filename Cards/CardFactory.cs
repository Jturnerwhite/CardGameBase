using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;

namespace Cards 
{
    public static class CardFactory 
    {
        public static List<Card> GetDeck(CharacterClass type) {
            DeckData[] decksLoaded = UnityEngine.Resources.LoadAll<DeckData>("Scriptables/DefaultDecks");
            Debug.Log($"Decks Loaded: {decksLoaded.Length}");

            switch(type) {
                case CharacterClass.Zealot:
                    return GetZealotDeck();
                case CharacterClass.Warrior:
                    return GetWarriorDeck();
                case CharacterClass.Vanguard:
                    return GetVanguardDeck();
                case CharacterClass.Gambler:
                    return GetGamblerDeck();
                default:
                    return GetWarriorDeck();
            }
        }

        public static List<Card> GetWarriorDeck() {
            List<Card> deck = new List<Card>();
            deck.Add(new Strike());
            deck.Add(new HorizonStrike());
            deck.Add(new HorizonStrike());
            deck.Add(new Strike());
            deck.Add(new Strike());
            deck.Add(new Rummage());
            deck.Add(new Rummage());
            deck.Add(new Rummage());
            deck.Add(new Rummage());
            return deck;
        }
        
        public static List<Card> GetZealotDeck() {
            List<Card> deck = new List<Card>();
            deck.Add(new Strike());
            deck.Add(new Strike());
            deck.Add(new Strike());
            deck.Add(new Strike());
            deck.Add(new Strike());
            return deck;
        }
        
        public static List<Card> GetVanguardDeck() {
            List<Card> deck = new List<Card>();
            deck.Add(new ScrapSlap());
            deck.Add(new ScrapSlap());
            deck.Add(new ArmorUp());
            deck.Add(new ArmorUp());
            deck.Add(new ArmorUp());
            return deck;
        }
        
        public static List<Card> GetGamblerDeck() {
            List<Card> deck = new List<Card>();
            deck.Add(new Jackpot());
            deck.Add(new SnakeEye());
            deck.Add(new LowBlow());
            deck.Add(new LowBlow());
            deck.Add(new LowBlow());
            deck.Add(new HighRoller());
            deck.Add(new HighRoller());
            return deck;
        }
    }
}