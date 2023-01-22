using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Resources {
    // A die is 'rolled' and has its value set to what is rolled.
    public class Die : Resource {
        private System.Random RNG;

        public Die(int amount = 0, int maxAmount = 6) : base(amount, maxAmount, "Die", ResourceType.Die, Color.cyan) {
            IsDisabled = false;
        }

        public int Roll(int adjustment = 0) {
            RNG = new System.Random(DateTime.Now.Millisecond + adjustment);
            int roll = RNG.Next(1, MaxAmount);
            Amount = roll + adjustment;
            IsDisabled = false;
            return Amount;
        }

        // SupplyResource increases the die value
        //public void SupplyResource(int addition, bool allowOverflow = false);

        // DepleteResource reduces the die value
        //public void DepleteResource(int depletion);

        public override void PayCost(int cost, AmountCheckType checkType = AmountCheckType.Exact, int adjustment = 0) {
            IsDisabled = true;
        }

        // Can this die be used as payment?
        public override bool CanCostBePaid(int cost, AmountCheckType checkType = AmountCheckType.Exact, int adjustment = 0) {
            return !IsDisabled && MeetsThreshold(cost, false, checkType, adjustment);
        }
    }
}