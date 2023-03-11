using System.Collections.Generic;
using Cards;
using Cards.Actions;

public class Reagent : Card {
    public List<ReagentAction> ReagentActions;

    public Reagent(string name, string description, Cost cost, int targetsNeeded) : base(name, description, cost, targetsNeeded) {
    }
}