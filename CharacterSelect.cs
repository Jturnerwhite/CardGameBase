using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;

public class CharacterSelect : MonoBehaviour
{
    public void OnWarriorSelect() {
        OnCharacterSelect(CharacterClass.Warrior);
    }
    public void OnZealotSelect() {
        OnCharacterSelect(CharacterClass.Zealot);
    }
    public void OnVanguardSelect() {
        OnCharacterSelect(CharacterClass.Vanguard);
    }
    public void OnGamblerSelect() {
        OnCharacterSelect(CharacterClass.Gambler);
    }

    public void OnCharacterSelect(CharacterClass type) {
        RunManager.SetCharacter(type);
        //SceneChanger.ChangeToMapScene();
    }
}