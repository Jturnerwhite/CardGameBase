using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Resources;

namespace UI {
    public class ResourceBar : ResourceUI {

        public PercentScale bar;
        public PercentScale previewBar;
        public Text resourceText;

        private Resource CurrentResource;

        void Awake() {

        }

        public override void Init(Resource resource, Transform parent, Vector2? position) {
            CurrentResource = resource;
            bar.SetColor(CurrentResource.Color);
            Color modColor = new Color(CurrentResource.Color.r + 0.75f, CurrentResource.Color.g + 0.75f, CurrentResource.Color.b + 0.75f);
            Debug.Log($"{CurrentResource.Color.r}, {CurrentResource.Color.g}, {CurrentResource.Color.b}");
            Debug.Log($"{modColor.r}, {modColor.g}, {modColor.b}");
            previewBar.SetColor(modColor);

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
            bar.UpdateScale(newPercent);

            UpdatePreview();
            UpdateText();
        }
        
        public void UpdatePreview() {
            int newPercent = (int)(CurrentResource.GetPendingPercent() * 100f);
            previewBar.UpdateScale(newPercent);
        }

        public void UpdateText() {
            if(resourceText) {
                int amount = CurrentResource.GetAmount();
                int pendingChange = CurrentResource.GetPendingChange();
                string left = CurrentResource.GetAmount().ToString();

                left += pendingChange > 0 ? $"+{pendingChange.ToString()}" : "";
                resourceText.text = $"{left} / {CurrentResource.GetMaxAmount().ToString()}";
            }
        }
    }
}
