using System;
using System.Collections.Generic;
using Cards.Actions;
using Characters.Classes;
using UnityEngine;

namespace Saves {

    [Serializable]
    public class SaveData {
        public string SaveName;
        public CharacterSaveData CharacterData;
    }
}