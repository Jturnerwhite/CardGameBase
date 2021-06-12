using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToCharacterSelect() {
        ChangeScene("CharacterSelect");
    }

    public void ChangeToOptionsScene() {
        ChangeScene("OptionsScene");
    }

    public void ChangeToMapScene() {
        ChangeScene("MapScene");
    }

    public void ChangeToBattleScene() {
        ChangeScene("BattleScene");
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
