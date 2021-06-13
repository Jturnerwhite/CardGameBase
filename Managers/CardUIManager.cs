using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UI;
using Cards;
using Characters;

public class CardUIManager : MonoBehaviour {
    public List<CardUI> Hand;

    public int DeckCount;
    public int DiscardCount;

    public CardUI CardUIPrefab;

    private System.Random rng;
    private Character linkedCharacter;
    
    private float cardRenderOffset = 3f;

    void FixedUpdate () {
        if(linkedCharacter != null) {
            DeckCount = linkedCharacter.CardManager.Deck.Count;
            DiscardCount = linkedCharacter.CardManager.Discard.Count;
        }
    }

    public void Init(Character character) {
        Hand = new List<CardUI>();
        linkedCharacter = character;
        linkedCharacter.CardManager.AddCardCallback = AddCard;
        linkedCharacter.CardManager.DrawCallback = Draw;
        linkedCharacter.CardManager.DiscardCallback = Discard;
    }

    public void AddCard(Card card) {
        AddCardUItoHand(card);
    }

    public void Draw(Card card) {
        AddCardUItoHand(card);
    }

    public void Discard(Card card) {
        List<CardUI> cardsBefore = new List<CardUI>();
        int indexOfMatch = -1;
        List<CardUI> cardsAfter = new List<CardUI>();
        CardUI match = null;

        for(int i = 0; i < Hand.Count; i++) {
            var potentialMatch = Hand.ElementAt(i);
            if(match == null) {
                if(potentialMatch.Card == card) {
                    match = potentialMatch;
                    indexOfMatch = i;
                } else {
                    cardsBefore.Add(potentialMatch);
                }
            } else {
                cardsAfter.Add(potentialMatch);
            }
        }

        if(match != null) {
            Hand.Remove(match);
            match.Discard();

            foreach(CardUI cardUI in cardsAfter) {
                var currentPos = cardUI.transform.localPosition;
                var newPos = new Vector3(currentPos.x + cardRenderOffset, currentPos.y, currentPos.z);
                cardUI.transform.localPosition = newPos;
            }
        } else {
            Debug.Log($"Tried to discard {card.Name} but it wasn't found in UI");
        }
    }

    public CardUI GenerateCardUI(Card data, Vector3 pos) {
        CardUI newCard = Instantiate(CardUIPrefab, pos, Quaternion.identity, transform);
        newCard.Initialize(data);

        return newCard;
    }

    public void AddCardUItoHand(Card card) {
        var index = Hand.Count;
        Debug.Log("Adding new card at index " + index);
        Hand.Add(GenerateCardUI(card, new Vector3(4.0f - (cardRenderOffset * index), -3.0f)));
    }
}
