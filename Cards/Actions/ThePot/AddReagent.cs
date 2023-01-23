using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {
    public class AddReagent : iAction {
        public Reagent reagent;

        public AddReagent(Reagent reagent) {
            this.reagent = reagent;
        }

        public void execute(List<Character> targets, Character source) {
            ThePot res = (ThePot)source.GetResource();
            res.AddReagent(reagent);
        }
    }
}