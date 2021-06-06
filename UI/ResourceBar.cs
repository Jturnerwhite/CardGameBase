using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Resources;

namespace UI {
    public class ResourceBar : ResourceUI {

        public PercentScale percentScale;
        private Resource CurrentResource;

        void Awake() {

        }

        public override void Init(Resource resource, Transform parent, Vector2? position) {
            CurrentResource = resource;
            percentScale.SetColor(CurrentResource.Color);

            transform.SetParent(parent, false);

            if(position.HasValue) {
                transform.position = position.Value;
            } else {
                new Vector2((parent.localPosition.x), (parent.localPosition.y + 1.5f));
            }
        }

        void FixedUpdate() {
            UpdateValue();
        }

        public override void UpdateValue() {
            int newPercent = (int)(CurrentResource.GetCurrentPercent() * 100f);
            percentScale.UpdateScale(newPercent);
        }
    }
}
