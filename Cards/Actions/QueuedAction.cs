using System.Collections;
using System.Collections.Generic;
using Characters;

namespace Cards.Actions {
    public class QueuedAction {
        public string Name;
        public Character Source;
        public List<Character> Targets;
        public iAction Action;

        public QueuedAction(string name, Character source, List<Character> targets, iAction action) {
            this.Name = name;
            this.Source = source;
            this.Targets = targets;
            this.Action = action;
        }

        public void Execute() {
            this.Action.Execute(Targets, Source);
        }
    }
}