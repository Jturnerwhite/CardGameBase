using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;

public class MapManager : MonoBehaviour
{
    public SceneChanger SceneChanger;
    public PlinkoPlayer Player;

    public Transform StartPosition;
    public Transform DropThreshold;

    public PlinkoPlayer PlayerPrefab;

    void Awake()
    {
        SceneChanger = GetComponent<SceneChanger>();
        Player = Instantiate(PlayerPrefab, StartPosition.position, Quaternion.identity);
        if(RunManager.Character != null) {
            Debug.Log(RunManager.Character.characterClass.ToString());
            Player.Init(RunManager.Character.characterClass);
        } else {
            Player.Init(CharacterClass.Warrior);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Event(Zone zone) 
    {
        SceneChanger.ChangeToBattleScene();
        Debug.Log("Zone triggered: " + zone.gameObject.name);
    }

    public bool IsValidDropoff(Vector2 playerPos) {
        return playerPos.y > DropThreshold.position.y;
    }

    public void OnPlayerDrag() {
        Player.OnDrag();
    }

    public void OnPlayerDrop() {
        var isValid = IsValidDropoff(Player.transform.position);

        if(isValid) {
            Player.OnDrop();
        } else {
            Player.transform.position = StartPosition.transform.position;
        }
    }
}