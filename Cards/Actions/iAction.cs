using System.Collections.Generic;
using Characters;

namespace Cards.Actions {
    public interface iAction {
        void execute(List<Character> Targets, Character Source);
    }
}