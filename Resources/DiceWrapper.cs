using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Resources {
    public class DiceWrapper : Resource {

        private Die[] Dice;

        public DiceWrapper(int amount = 2, int maxAmount = 5) : base(amount, maxAmount, "DiceWrapper", ResourceType.Die, Color.gray) {
            Dice = new Die[maxAmount];

            for(var i = 0; i < amount; i++) {
                Dice[i] = new Die(1, 6);
            }

            RollAll();
        }

        public void RollAll() {
            for(var i = 0; i < Amount; i++) {
                Dice[i].Roll(i);
            }
        }

        public override Resource[] GetSubResources() {
            return Dice;
        }

        // Dice can be added
        public override void SupplyResource(int dieIndex, bool allowOverflow = false) {
            if(dieIndex > MaxAmount || dieIndex < 0) {
                return;
            }

            Dice[dieIndex] = null;
            Dice[dieIndex] = new Die(1, 6);
        }

        // Dice can be removed
        public override void DepleteResource(int dieIndex) {
            if(dieIndex > MaxAmount || dieIndex < 0) {
                return;
            }

            Dice[dieIndex] = null;
        }

        // A die is consumed to pay a cost
        public override void PayCost(int cost, AmountCheckType checkType = AmountCheckType.Exact, int adjustment = 0) {
            Die dieToConsume = FindDieForCost(cost, checkType, adjustment);
            if(dieToConsume != null) {
                dieToConsume.IsDisabled = true;
            }
        }

		public override bool CanCostBePaid(int cost, AmountCheckType checkType = AmountCheckType.Exact, int adjustment = 0) {
            return FindDieForCost(cost, checkType, adjustment) != null;
		}

        public Die FindDieForCost(int cost, AmountCheckType checkType, int adjustment = 0) {
            Die output = null;

            for(var i = 0; i < Amount; i++) {
                var checkDie = Dice[i];
                if(checkDie.CanCostBePaid(cost, checkType, adjustment)) {
                    output = checkDie;
                    break;
                }
            }

            return output;
        }
    }
}