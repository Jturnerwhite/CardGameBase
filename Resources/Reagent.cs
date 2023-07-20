using System.Collections.Generic;
using Cards;
using Cards.Actions;


namespace Resources {
    public class Reagent {
        public string Name;
        public List<ReagentPiece> Pieces;
    }

    public class ReagentPiece {
        public SubActionData Origin;
        public iAction Action;
    }
}