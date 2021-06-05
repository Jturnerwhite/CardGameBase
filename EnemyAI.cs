using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Resources;
using Characters;
using Characters.Classes;
using Characters.Enemies;
using Cards;
using UI;

public class EnemyAI : MonoBehaviour
{
    private ActionManager ActionManager;
    private BattleManager BattleManager;

    private System.Random rng;

    private Actor ActorComp;
    List<Card> StartingDeck;

    void Awake() {
        this.ActionManager = Camera.main.GetComponent<ActionManager>();
        this.BattleManager = Camera.main.GetComponent<BattleManager>();
        rng = new System.Random();

        ActorComp = GetComponent<Actor>();
        StartingDeck = new List<Card>();
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
    }

    void FixedUpdate() {

    }

    public Card ChooseCast() {
        Shuffle(StartingDeck);
        return StartingDeck.First();
    }

    public void Shuffle(IList<Card> list)  {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            Card value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }
    }
}