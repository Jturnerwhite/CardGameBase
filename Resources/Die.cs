using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources {
    // A die is 'rolled' and has its value set to what is rolled.
    public class Die : Resource {
        public Die(int amount = 0, int maxAmount = 6) : base(amount, maxAmount, "Die", (int)ResourceType.Die) {

        }

        public override void DepleteResource(int depletion) {
            Amount = 0;
        }
    }
}