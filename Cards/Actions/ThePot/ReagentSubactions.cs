using System;
using System.Collections.Generic;
using System.Linq;
using Resources;
using Characters;

namespace Cards.Actions {
    public class ReagentSubactions : iAction {
        private string ReagentName;
        private List<Tuple<SubActionData, iAction>> Subactions;

        public ReagentSubactions(string reagentName, ActionData serializedAction, List<iAction> serliazedSubactions) {
            ReagentName = reagentName;
            Subactions = new List<Tuple<SubActionData, iAction>>();
            for(var i = 0; i < serializedAction.SubActions.Length; i++) {
                Subactions.Add(Tuple.Create(serializedAction.SubActions[i], serliazedSubactions[i]));
            }
        }

        public void execute(List<Character> targets, Character source) {
            ((ThePot)source.GetResource()).AddReagent(ReagentName, Subactions);
        }
    }
}