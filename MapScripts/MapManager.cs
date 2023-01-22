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
            Player.Init(RunManager.Character.CharacterClass, StartPosition.position, DropThreshold.position);
        } else {
            Player.Init(CharacterClass.Warrior, StartPosition.position, DropThreshold.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Event(Zone zone) 
    {
        RunManager.PrepareForBattle(zone, Player.transform.position);
        SceneChanger.ChangeToBattleScene();
        Debug.Log("Zone triggered: " + zone.gameObject.name);
    }
}