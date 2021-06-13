using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;
using Characters.Classes;
using Cards;

public static class RunManager
{
    public static Character Character;
    public static List<Card> Deck;

    public static void SetCharacter(CharacterClass cClass) {
        Character = CharacterFactory.Get(cClass);
        Deck = CardFactory.GetDeck(cClass);
        Character.CardManager.Init(Deck);
    }

    public static void CompleteBattle(Character character) {
        Character = character;
        Character.CardManager.HardReset();
        Deck = Character.CardManager.Deck;
    }

    public static void PrepareForBattle() {
        Character.CardManager.SetCards(Deck);
    }
}