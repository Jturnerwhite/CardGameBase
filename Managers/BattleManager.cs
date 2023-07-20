using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cards;
using Characters.Classes;

public class BattleManager : MonoBehaviour {

    public Actor[] ClassPrefabs;
    public Actor EnemyBase;

// temp
    public Text DeckDisplay;
    public Text DiscardDisplay;
    public Text FightWin;
// end temp

    public Actor Player {get;set;}
    public Actor Enemy {get;set;}

    public CardUIManager CardManagerPrefab;
    public CardUIManager CardUIManager {get;set;}

    void Awake() {
        Initialize();
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        DeckDisplay.text = "Deck: " + CardUIManager.DeckCount;
        DiscardDisplay.text = "Discard: "  + CardUIManager.DiscardCount;

        if(Enemy == null) {
            FightWin.gameObject.SetActive(true);
            SceneChanger.ChangeToMapScene();
            RunManager.CompleteBattle(Player.characterStats);
        }
    }

    public void Initialize() {
        InitPlayer();
        InitCardUIManager();
        InitEnemies();

        Player.StartTurnTrigger();
    }

    public void InitEnemies() {
        Enemy = Instantiate(EnemyBase, new Vector3(6, 0), Quaternion.identity) as Actor;
        Enemy.Initialize(null, null);
    }

    public void InitPlayer() {
        Debug.Log($" Runman Class: {RunManager.Character.CharacterClass}");
        var indexToUse = (RunManager.Character != null) ? RunManager.Character.CharacterClass : CharacterClass.Warrior;
        Debug.Log($"Index: {indexToUse}");

        Player = Instantiate(ClassPrefabs[(int)indexToUse], new Vector3(-6, 0), Quaternion.identity) as Actor;
        Player.Initialize(RunManager.Character, RunManager.Deck);
    }

    public void InitCardUIManager() {
        CardUIManager = Instantiate(CardManagerPrefab, new Vector3(0, -4.5f), Quaternion.identity);
        GetComponent<EventManager>().SetCardManager(CardUIManager);
        CardUIManager.Init(Player.characterStats);
        Player.characterStats.CardManager.SetCards(CardFactory.GetDeck(Player.CharacterClass));
    }

    public List<Actor> GetAllEnemies() {
        var output = new List<Actor>();
        output.Add(Enemy);

        return output;
    }

    public Actor GetPlayer() {
        return Player;
    }
}
