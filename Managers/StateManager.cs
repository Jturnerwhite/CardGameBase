using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

public enum CastState {
    SelectCard,
    SelectActors,
    Casting
}

public enum MetaState {
    Active,
    Paused //esc menu open
}

public class StateManager : MonoBehaviour {
    
    public Text DebugText;

    //public MetaState MetaState {get;set;}
    public bool IsPlayerTurn {get;set;}
    public CastState CastState {get;set;}
    public CardUI CurrentCard {get;set;}
    public List<Actor> SelectedActors {get;set;}

    private BattleManager BattleManager;

    void Awake() {
        Initialize();
    }

    void FixedUpdate() {
        DebugText.text = "State: " + this.CastState.ToString();
    }

    public void Initialize() {
        //MetaState = MetaState.Active;
        BattleManager = transform.GetComponent<BattleManager>();
        IsPlayerTurn = true;
        SetInitialCastState();
    }

    public void SetInitialCastState() {
        CastState = CastState.SelectCard;
        CurrentCard = null;
        SelectedActors = new List<Actor>();
    }

    public void PassTurn() {
        IsPlayerTurn = !IsPlayerTurn;

        if(IsPlayerTurn) {
            SetInitialCastState();
        }
    }

    public void SelectCard(CardUI card) {
        Debug.Log("State Manager: Card Selected: " + card.card.Name);
        CurrentCard = card;

        if(CurrentCard.card.TargetsNeeded == 0) {
            CastState = CastState.Casting;
        } else if(CurrentCard.card.TargetsNeeded == -1) {
            SelectedActors.AddRange(BattleManager.GetAllEnemies());
            CastState = CastState.Casting;
        } else {
            CastState = CastState.SelectActors;
        }
    }

    public void DeselectCard() {
        Debug.Log("State Manager: Card Deselected");
        CurrentCard = null;
        CastState = CastState.SelectCard;
    }

    public void AddSelectedActor(Actor actor) {
        SelectedActors.Add(actor);

        if(SelectedActors.Count == CurrentCard.card.TargetsNeeded) {
            CastState = CastState.Casting;
        }
    }

    public void RemoveSelectedActor(Actor actor) {
        SelectedActors.Remove(actor);
    }

    public void CompleteCast() {
        SetInitialCastState();
    }
}