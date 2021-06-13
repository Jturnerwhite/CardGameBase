using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger {
    public static void ChangeToCharacterSelect() {
        ChangeScene("CharacterSelect");
    }

    public static void ChangeToOptionsScene() {
        ChangeScene("OptionsScene");
    }

    public static void ChangeToMapScene() {
        ChangeScene("MapScene");
    }

    public static void ChangeToBattleScene() {
        ChangeScene("BattleScene");
    }

    public static void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
