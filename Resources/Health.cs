using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources {
    // These are so empty because the class it inherits, Resource, has all the basic functions
    public class Health : Resource {
        public Health(int amount, int maxAmount) : base(amount, maxAmount, "Health", 1) {

        }
    }
}