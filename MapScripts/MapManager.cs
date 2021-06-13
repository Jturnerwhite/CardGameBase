using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.Classes;

public class MapManager : MonoBehaviour
{
    public PlinkoPlayer Player;

    public Transform StartPosition;
    public Transform DropThreshold;

    public PlinkoPlayer PlayerPrefab;

    void Awake()
    {
        Player = Instantiate(PlayerPrefab, StartPosition.position, Quaternion.identity);
        if(RunManager.Character != null) {
            Debug.Log(RunManager.Character.CharacterClass.ToString());
            Player.Init(RunManager.Character.CharacterClass);
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
        RunManager.PrepareForBattle();
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