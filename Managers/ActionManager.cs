using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cards;
using Cards.Actions;
using Characters;

public class ActionManager : MonoBehaviour {
    public bool CastCard(Card card, Actor source, List<Actor> targets) {
        if(source.characterStats.CanCastCard(card)) {
            var charTargets = targets.Select(x => x.characterStats).ToList();
            source.characterStats.CastCard(card, charTargets);
            PerformActions(card, source.characterStats, charTargets);

            return true;
        } else {
            return false;
        }
    }

    public void PerformActions(Card card, Character source, List<Character> targets) {
        foreach(var action in card.Actions) {
            action.Execute(targets, source);
        }
    }

    public void PerformQueuedActions(List<QueuedAction> queuedActions) {
        foreach(var action in queuedActions) {
            action.Execute();
        }
    }
}