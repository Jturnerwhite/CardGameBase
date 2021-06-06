using System.Collections.Generic;
using Cards.Actions;
using Utils;

namespace Cards {
    public class SnakeEye : Card {
        public SnakeEye() : base("SnakeEye", "Deal 1 damage to 1 target, twice.", new Cost(1, AmountCheckType.Exact), 1) {
            Actions = new List<iAction>();
            Actions.Add(new ToDamage(1));
            Actions.Add(new ToDamage(1));
        }
    }
}