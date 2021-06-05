using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cards;

//D:\UnityGithub\WhiteOpal\CardGame\Assets\Scripts\Combat\ConcreteClasses\Cards
public class BattleManager : MonoBehaviour {

    public Actor PlayerBase;
    public Actor EnemyBase;

    public Text DeckDisplay;
    public Text DiscardDisplay;
    public Text FightWin;

    public Actor Player {get;set;}
    public Actor Enemy {get;set;}

    public CardManager CardManagerPrefab;
    public CardManager CardManager {get;set;}

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
        DeckDisplay.text = "Deck: " + CardManager.Deck.Count;
        DiscardDisplay.text = "Discard: " + CardManager.Discard.Count;

        if(Enemy == null) {
            Debug.Log("You won the fight");
            FightWin.gameObject.SetActive(true);
        }
    }

    public void Initialize() {
        Player = Instantiate(PlayerBase, new Vector3(-6, 0), Quaternion.identity) as Actor;
        Enemy = Instantiate(EnemyBase, new Vector3(6, 0), Quaternion.identity) as Actor;
        CardManager = Instantiate(CardManagerPrefab, new Vector3(0, -4.5f), Quaternion.identity);
        GetComponent<EventManager>().SetCardManager(CardManager);
        CardManager.Init(CardFactory.GetDeck(Player.CharacterClass));
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
