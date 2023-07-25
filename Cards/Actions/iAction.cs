using System.Collections.Generic;
using Characters;


namespace Cards.Actions {
    public interface iAction {
        void Execute(List<Character> Targets, Character Source);
    }
}