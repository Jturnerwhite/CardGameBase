using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public SceneChanger SceneChanger;

    public Transform StartPosition;
    public Transform DropThreshold;

    public PlinkoPlayer Player;

    void Awake()
    {
        SceneChanger = GetComponent<SceneChanger>();
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