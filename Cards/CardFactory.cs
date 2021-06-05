using System.Collections.Generic;
using Characters.Classes;

namespace Cards 
{
    public static class CardFactory 
    {
        public static List<Card> GetDeck(CharacterClass type) {
            switch(type) {
                case CharacterClass.Zealot:
                    return GetZealotDeck();
                case CharacterClass.Warrior:
                    return GetWarriorDeck();
                case CharacterClass.Vanguard:
                    return GetVanguardDeck();
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
    }
}