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

    private CardManager cardManager;

    void Start() {
        this.ActionManager = Camera.main.GetComponent<ActionManager>();
        this.BattleManager = Camera.main.GetComponent<BattleManager>();
        rng = new System.Random();

        var ActorComp = GetComponent<Actor>();
        cardManager = ActorComp.characterStats.CardManager;

        List<Card> StartingDeck = new List<Card>();
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        cardManager.Init(StartingDeck);
    }

    void FixedUpdate() {

    }

    public Card ChooseCast() {
        cardManager.Shuffle(cardManager.Deck);
        return cardManager.TopDeck();
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