using System;

namespace Cards.Actions {
    [Serializable]
    public enum ActionType {
        ToDamage,
        ToDamageWithThreshold,
        ToDiscard,
        ToDraw,
        ToRestore,
        ReagentAction,
        ChangeTarget,
        Brew,
        ToDeplete,
        ToReroll
    }
}