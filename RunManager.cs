using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;
using Characters.Classes;
using Cards;
using Saves;

// Holds cross-scene data
public static class RunManager
{
    public static Character Character;
    public static List<CardData> Deck;

    public static Vector3 MapPosition;
    public static Zone EventZone;

    public static void StartRun(CharacterClass cClass) {
        Debug.Log($"Selected Character Class: {cClass}");
        Character = CharacterFactory.Get(cClass);
        Deck = CardFactory.GetDeckData(cClass).Cards;

        Debug.Log($"Character Loaded: {Character.Name} {Character.CharacterClass} : Deck: {Deck.Count}");
        SaveManager.CreateNewSave(Character, Deck, $"newsave_{Character.Name}");
    }

    public static void LoadRun() {
        SaveData save = SaveManager.Load();
        if(save != null) {
            Character = CharacterFactory.Get(save.CharacterData);
            Deck = save.CharacterData.Deck;
        }
    }

    public static void CompleteBattle(Character character) {
        Character = character;
        Save(Character, Deck);
    }

    public static void PrepareForBattle(Zone eventZone, Vector3 position) {
        MapPosition = position;
        EventZone = eventZone;
    }

    public static void Save(Character character, List<CardData> deck) {
        Character = character;
        Deck = deck;
        SaveManager.Save(Character, Deck);
    }
}