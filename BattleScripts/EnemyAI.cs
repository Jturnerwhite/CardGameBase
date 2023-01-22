using System.Collections.Generic;
using UnityEngine;
using Cards;

public class EnemyAI : MonoBehaviour
{
    private ActionManager ActionManager;
    private BattleManager BattleManager;
    private Actor ActorComp;
    private CardManager cardManager;
    private System.Random rng;

    void Start() {
        ActionManager = Camera.main.GetComponent<ActionManager>();
        BattleManager = Camera.main.GetComponent<BattleManager>();
        rng = new System.Random();

        ActorComp = GetComponent<Actor>();
        cardManager = ActorComp.characterStats.CardManager;

        InitDeck();
    }

    public void InitDeck() {
        List<Card> StartingDeck = new List<Card>();
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        StartingDeck.Add(new Strike());
        cardManager.Init(StartingDeck);
    }

    public void TakeTurn() {
        Card cardSelected = ChooseCast();
        List<Actor> targets = new List<Actor>();
        targets.Add(BattleManager.GetPlayer());

        ActionManager.CastCard(cardSelected, ActorComp, targets);
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