using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Resources;

namespace UI {
    public class ResourceUI : MonoBehaviour {
        private Resource currentResource;
        private PercentScale percentScale;

        public ResourceUI(Resource actorResource, Transform actorTransform, PercentScale bar, float counter) {
            currentResource = actorResource;
            percentScale = bar;
            percentScale.transform.SetParent(actorTransform, false);
            percentScale.transform.position = new Vector2((actorTransform.localPosition.x), (actorTransform.localPosition.y + counter));
            percentScale.SetType(currentResource.Type);
        }

        public void updateValue() {
            int newPercent = (int)(currentResource.GetCurrentPercent() * 100f);
            percentScale.UpdateScale(newPercent);
        }
    }
}
