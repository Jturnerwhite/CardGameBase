using System;
using System.Collections.Generic;
using Resources;
using Characters;

namespace Cards.Actions {

    // A type of action that is more concrete in order to be modifyable by other actions
    public class ReagentAction : iAction {
        public ReagentType Type;
        public int Amount;

        public ReagentAction(ReagentType type, int amount) {
            Type = type;
            Amount = amount;
        }

        public ReagentAction(ActionData serializedAction) {
            string valuesCSV = serializedAction.Value;
            string[] values = valuesCSV.Split(',');

            Type = ReagentType.Heal;
            if(values.Length > 0) {
                Enum.TryParse<ReagentType>(values[0], true, out Type);
            }

            Amount = 1;
            if(values.Length > 1) {
                Amount = Int32.Parse(values[1]);
            }
        }

        public void ModifySelf(int amount) {
            ModifySelf(this.Type, amount);
        }
        public void ModifySelf(ReagentType type) {
            ModifySelf(type, this.Amount);
        }
        public void ModifySelf(ReagentType type, int amount) {
            Type = type;
            Amount = amount;
        }

        public void execute(List<Character> targets, Character source) {
            // technically no execution occurs here, and is instead handled by ThePot
        }
    }
}