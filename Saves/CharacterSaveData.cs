using System;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using Characters.Classes;

namespace Saves {

    [Serializable]
    public class CharacterSaveData {
        public string Name;
        public CharacterClass CharacterClass;
        public int CurrentHP;
        public int MaxHP;
        public List<CardData> Deck;

        public ResourceSaveData ResourceData;
    }
}