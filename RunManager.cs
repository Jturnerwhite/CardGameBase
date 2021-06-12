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
    }
}