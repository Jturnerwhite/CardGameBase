using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
