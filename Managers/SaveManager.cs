using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cards;
using Characters.Classes;
using Saves;
using ToolBox.Serialization;
using Characters;

namespace Saves {
    //https://github.com/IntoTheDev/Save-System-for-Unity
    public static class SaveManager {
        private const string SAVE_KEY = "RUN_SAVE";

        public static void CreateNewSave(Character selectedCharacter, List<Card> deck, string saveName) {
            CheckSave();

            SaveData newSave = new SaveData() {
                CharacterData = selectedCharacter.GetCharacterSaveData()
            };

            List<CardSaveData> newDeckSave = new List<CardSaveData>();
            foreach(var card in deck) {
                newDeckSave.Add(new CardSaveData(){ Name = card.Name });
            }

            newSave.CharacterData.Deck = newDeckSave;

            Save(newSave);
        }

        public static void CheckSave() {
            if (DataSerializer.HasKey(SAVE_KEY)) {
                SaveData savedData = DataSerializer.Load<SaveData>(SAVE_KEY);
                Debug.Log($"Save Detected: {savedData.SaveName} Class: {savedData.CharacterData.Name} CurrHP: {savedData.CharacterData.CurrentHP}");
            } else {
                Debug.Log($"No Save Detected");
            }
        }

        public static void Save(SaveData saveData) {
            DataSerializer.Save(SAVE_KEY, saveData);
        }

        public static SaveData Load() {
            if (DataSerializer.TryLoad<SaveData>(SAVE_KEY, out SaveData loadedData))
            {
                return loadedData;
            }

            return null;
        }
    }
}