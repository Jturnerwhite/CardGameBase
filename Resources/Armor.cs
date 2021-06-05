using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources {
    // These are so empty because the class it inherits, Resource, has all the basic functions
    public class Armor : Resource {
        public Armor(int amount, int maxAmount) : base(amount, maxAmount, "Armor", (int)ResourceType.Armor, Color.gray) {

        }

        public override void DepleteResource(int depletion)
        {
            base.DepleteResource(depletion);

            if(Amount < 0) {
                Amount = 0;
            }
        }
    }
}