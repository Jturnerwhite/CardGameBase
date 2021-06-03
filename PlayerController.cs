using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Cards;
using Characters;

public enum PlayerSelectionState {
    SelectCard, SelectTarget, Disabled
}

public class PlayerController {
    public PlayerSelectionState currentState { get; set; }
    public CardUI currentCardSelected { get; set; }

    public PlayerController() {
    }

    public void CardClicked(CardUI cardUI) {
        Debug.Log(cardUI.card.Name);
    }
}
