using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources {
    // These are so empty because the class it inherits, Resource, has all the basic functions
    public class Stamina : Resource {
        public Stamina(int amount, int maxAmount) : base(amount, maxAmount, "Stamina", ResourceType.Stamina, Color.green) {
            
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