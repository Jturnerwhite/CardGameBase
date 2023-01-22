using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;

namespace Cards 
{
    public static class DeckFactory 
    {
        public static List<CardData> GetDeck(CharacterClass type) {
            DeckData[] decksLoaded = UnityEngine.Resources.LoadAll<DeckData>("Scripts/Cards/Scriptables/DefaultDecks");
            Debug.Log($"Decks Loaded: {decksLoaded.Length}");

            if(decksLoaded.Length == 0) {
                return null;
            }

            List<CardData> deck = decksLoaded[0].Cards;

            switch(type) {
                case CharacterClass.Zealot:
                case CharacterClass.Warrior:
                case CharacterClass.Vanguard:
                case CharacterClass.Gambler:
                default:
                    break;
            }

            return deck;
        }
    }
}