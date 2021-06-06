using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;

namespace UI {
    public abstract class MultiResourceUI : MonoBehaviour {
        public List<Resource> Resources;
        public ResourceUI ActiveResouce;

        public abstract void Init(List<Resource> actorResource);

        public abstract void UpdateValue();
    }
}
