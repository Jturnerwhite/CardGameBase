using System.Collections;
using System.Collections.Generic;
using Cards;

namespace Cards.Actions {
    public static class ActionFactory {
        public static iAction ConstructAction(ActionData serializedAction, Card card = null) {
            switch(serializedAction.Type) {
                case ActionType.ToDamage:
                    return new ToDamage(serializedAction);
                case ActionType.ToDamageWithThreshold:
                    return new ToDamageWithThreshold(serializedAction);
                case ActionType.ToDiscard:
                    return new ToDiscard(serializedAction);
                case ActionType.ToDraw:
                    return new ToDraw(serializedAction);
                case ActionType.ToRestore:
                    return new ToRestore(serializedAction);
                case ActionType.ToHeal:
                    return new ToHeal(serializedAction);
                case ActionType.ReagentAction:
                    return new ReagentAction(serializedAction);
                case ActionType.ChangeTarget:
                    return new ChangeTarget(serializedAction);
                case ActionType.Brew:
                    return new Brew();
                case ActionType.ToDeplete:
                    return new ToDeplete(serializedAction);
                case ActionType.ToReroll:
                    return new ToReroll(serializedAction);
                case ActionType.ReagentSubactions:
                    return new ReagentSubactions(card.Name, serializedAction, ConstructAllSubactions(serializedAction, card));
                default:
                    return new ToRestore(0);
            }
        }

        public static List<iAction> ConstructAllSubactions(ActionData serializedAction, Card card = null) {
            List<iAction> subActions = new List<iAction>();

            foreach(var subActionData in serializedAction.SubActions) {
                ActionData newData = new ActionData() {
                    Type = subActionData.Type,
                    Value = subActionData.Value
                };
                subActions.Add(ConstructAction(newData, card));
            }

            return subActions;
        }
    }
}