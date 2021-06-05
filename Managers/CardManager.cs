using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UI;
using Cards;

public class CardManager : MonoBehaviour {
    public List<Card> Deck;
    public List<Card> Hand;
    public List<Card> Discard;

    public CardUI CardUIPrefab;

    private System.Random rng;

    void Awake() {
    }

    public void Init(List<Card> startingDeck) {
        Deck = startingDeck ?? new List<Card>();
        Hand = new List<Card>();
        Discard = new List<Card>();
        rng = new System.Random();

        DrawHand();
    }

    public void SetCards(List<Card> cards) {
        Deck = cards;
    }

    public CardUI GenerateCardUI(Card data, Vector3 pos) {
        CardUI newCard = Instantiate(CardUIPrefab, pos, Quaternion.identity, transform);
        newCard.Initialize(data);

        return newCard;
    }

    public void CastCard(CardUI cardUI) {
        cardUI.Discard();
        DiscardFromHand(cardUI.card);
    }

    public List<Card> DrawHand(int count = 3) {
        float x = -4.0f;
        float y = -3.0f;
        float increment = 3f;

        for(int i = 0; i < count; i++) {
            GenerateCardUI(Draw(), new Vector3(x, y));
            x += increment;
        }

        return Hand;
    }

    public void DiscardFromHand(Card card) {
        Hand.Remove(card);
        Discard.Add(card);
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
