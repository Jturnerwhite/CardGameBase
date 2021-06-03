using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager 
{
    public bool isPlayerTurn;

    public TurnManager(bool startOnPlayerTurn) 
    {
        isPlayerTurn = startOnPlayerTurn;
    }

    public void PassTurn() {
        isPlayerTurn = !isPlayerTurn;
    }
}