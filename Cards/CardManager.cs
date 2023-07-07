using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cards;
using Saves;

namespace Cards {
    public class CardManager {
        public List<Card> Deck;
        public List<Card> Hand;
        public List<Card> Discard;

        private System.Random rng;

        public delegate void AddCardCallbackD(Card card);
        public delegate void DrawCallbackD(Card card);
        public delegate void DiscardCallbackD(Card card);

        public AddCardCallbackD AddCardCallback;
        public DrawCallbackD DrawCallback;
        public DiscardCallbackD DiscardCallback;

        public void Init(List<Card> startingDeck) {
            Deck = startingDeck ?? new List<Card>();
            Hand = new List<Card>();
            Discard = new List<Card>();
            rng = new System.Random();
        }

        public void InitFromSave(List<CardData> savedDeck) {
            Deck = new List<Card>();
            CardFactory.ConstructDeck(savedDeck);
            Hand = new List<Card>();
            Discard = new List<Card>();
            rng = new System.Random();
        }

        public void SetCards(List<Card> cards) {
            Deck = cards;
        }

        public void CastCard(Card card) {
            DiscardFromHand(card);
        }

        public List<Card> DrawHand(int count = 3) {
            for(int i = 0; i < count; i++) {
                Draw();
            }

            return Hand;
        }

        public void DiscardHand() {
            foreach(var card in Hand) {
                DiscardCallback(card);
            }
            Discard.AddRange(Hand);
            Hand = new List<Card>();
        }

        public void DiscardFromHand(Card card) {
            Hand.Remove(card);
            Discard.Add(card);
            DiscardCallback(card);
        }

        public void DiscardFromHand(int index = 0) {
            var card = Hand.ElementAt(index);
            if(card != null) {
                DiscardFromHand(card);
            }
        }

        public Card Draw() {
            Card top = TopDeck();

            if(top == null) {
                ResetDeck();
                top = TopDeck();
            }

            Hand.Add(top);
            Deck.Remove(top);

            DrawCallback(top);
            return top;
        }

        public Card TopDeck() {
            return Deck.FirstOrDefault();
        }

        public Card DrawSpecific(int index) {
            Card cardToDraw = Deck.ElementAt(index);
            Hand.Add(cardToDraw);
            Deck.Remove(cardToDraw);

            DrawCallback(cardToDraw);

            return cardToDraw;
        }
        
        public Card DrawRandom() {
            var randCard = GetRandom(Deck);
            Hand.Add(randCard);
            Deck.Remove(randCard);

            DrawCallback(randCard);

            return randCard;
        }

        public void ResetDeck() {
            Deck.AddRange(Discard);
            Shuffle(Deck);
            Discard = new List<Card>();
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

        private Card GetRandom(List<Card> cards) {
            var index = rng.Next(0, cards.Count);
            return cards.ElementAt(index);
        }

        public Card DiscardRandom() {
            var randCard = GetRandom(Hand);
            DiscardFromHand(randCard);
            return randCard;
        }

        public void HardReset() {
            Deck.AddRange(Hand);
            Deck.AddRange(Discard);
            Hand = new List<Card>();
            Discard = new List<Card>();
        }
    }
}