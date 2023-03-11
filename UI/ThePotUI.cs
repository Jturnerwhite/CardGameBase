using UnityEngine;
using Resources;
using UnityEngine.UI;

namespace UI {
    public class ThePotUI : ResourceUI {
        public Text potCount;

        private ThePot CurrentResource;

        void Awake() {

        }

        void FixedUpdate() {
            UpdateValue();
        }

        public override void Init(Resource resource, Transform parent, Vector2? position) {
            CurrentResource = (ThePot)resource;

            if(position.HasValue) {
                transform.position = position.Value;
            } else {
                new Vector2((parent.localPosition.x), (parent.localPosition.y + 1.5f));
            }
        }

        public override void UpdateValue() {
            UpdateCount();
        }

        public void UpdateCount() {
            Debug.Log($"{this.CurrentResource.GetAmount()}");
            potCount.text = $"Count: {this.CurrentResource.GetAmount()} reagents";
        }
    }
}