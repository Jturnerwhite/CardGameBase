using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards {
    public class CardManager {
        public List<Card> Deck;
        public List<Card> Hand;
        public List<Card> Discard;

        private Random rng;

        public CardManager() {
            Deck = new List<Card>();
            Hand = new List<Card>();
            Discard = new List<Card>();
            rng = new Random();
        }

        public List<Card> DrawHand(int count = 5) {
            for(int i = 0; i < count; i++) {
                Draw();
            }

            return Hand;
        }

        public void DiscardFromHand(Card card) {
            Hand.Remove(card);
        }
        
        public void DiscardFromHand(int index = 0) {
            DiscardFromHand(Hand.ElementAt(index));
        }

        public Card Draw() {
            Card top = TopDeck();

            if(top == null) {
                ResetDeck();
                top = TopDeck();
            }

            Hand.Add(top);

            return top;
        }

        public Card TopDeck() {
            return Deck.FirstOrDefault();
        }

        public void ResetDeck() {
            Deck.AddRange(Discard);
            Shuffle(Deck);
            Deck = new List<Card>();
        }

        public void Shuffle(IList<Card> list)  {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                Card value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }
        }
    }
}