using UnityEngine;
using Cards;
using UI;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
    private ActionManager ActionManager;
    private BattleManager BattleManager;
    private StateManager StateManager;
    private CardManager CardManager;

    void Awake() {
        this.ActionManager = transform.GetComponent<ActionManager>();
        this.BattleManager = transform.GetComponent<BattleManager>();
        this.StateManager = transform.GetComponent<StateManager>();
    }

    public void SetCardManager(CardManager CardManager) {
        this.CardManager = CardManager;
    }

    public void CardClicked(CardUI card) {
        if (StateManager.CastState == CastState.SelectCard) {
            StateManager.SelectCard(card);
            card.ToggleHighlight();
        }
        else if (StateManager.CastState == CastState.SelectActors) {
            if(card == StateManager.CurrentCard) {
                StateManager.CurrentCard.ToggleHighlight();
                StateManager.DeselectCard();
            } else {
                StateManager.CurrentCard.ToggleHighlight();
                StateManager.SelectCard(card);
                StateManager.CurrentCard.ToggleHighlight();
            }
        }

        if(StateManager.CastState == CastState.Casting) {
            CastCommence();
        }
    }

    public void ActorClicked(Actor actor) {
        Debug.Log("Actor Clicked");
        if (StateManager.CastState == CastState.SelectActors) {
            if(StateManager.SelectedActors.Contains(actor)) {
                StateManager.RemoveSelectedActor(actor);
            } else {
                StateManager.AddSelectedActor(actor);
            }

            if(StateManager.CastState == CastState.Casting) {
                CastCommence();
            }
        }
    }

    public void CastCommence() {
        bool castSuccessful = ActionManager.CastCard(StateManager.CurrentCard.card, BattleManager.Player, StateManager.SelectedActors);

        if(castSuccessful) {
            StateManager.CurrentCard.ToggleHighlight();
            CardManager.CastCard(StateManager.CurrentCard);
            StateManager.CompleteCast();
        } else {
            StateManager.CurrentCard.ToggleHighlight();
            StateManager.DeselectCard();
        }
    }

    public void PassTurnClicked() {
        StateManager.PassTurn();

        foreach(var enemy in BattleManager.GetAllEnemies()) {
            EnemyTurnCommence(enemy);
        }
    }

    public void EnemyTurnCommence(Actor enemy) {
        Card cardSelected = enemy.GetComponent<EnemyAI>().ChooseCast();
        List<Actor> targets = new List<Actor>();
        targets.Add(BattleManager.GetPlayer());

        ActionManager.CastCard(cardSelected, enemy, targets);
    }
}