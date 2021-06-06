using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;

namespace UI {
    public abstract class ResourceUI : MonoBehaviour {
        public abstract void Init(Resource resource, Transform transform, Vector2? position);

        public abstract void UpdateValue();
    }
}