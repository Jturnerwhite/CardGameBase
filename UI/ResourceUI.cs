using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;

namespace UI {
    public class ResourceUI : MonoBehaviour {

        public PercentScale percentScale;
        private Resource currentResource;

        void Awake() {

        }

        public void Init(Resource actorResource) {
            currentResource = actorResource;
            //percentScale.transform.SetParent(actorTransform, false);
            //percentScale.transform.position = new Vector2((actorTransform.localPosition.x), (actorTransform.localPosition.y + counter));
            percentScale.SetColor(currentResource.Color);
        }

        void FixedUpdate() {
            updateValue();
        }

        public void updateValue() {
            int newPercent = (int)(currentResource.GetCurrentPercent() * 100f);
            percentScale.UpdateScale(newPercent);
        }
    }
}
