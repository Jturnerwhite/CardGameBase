using UnityEngine;
using Resources;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace UI {
    public class ThePotUI : ResourceUI {
        public Text potCount;

        public ReagentUI ReagentUIPrefab;
        public Transform ReagentAnchorStart;

        public List<ReagentUI> ReagentUIs;

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
            UpdateReagents();
        }

        public void UpdateCount() {
            potCount.text = $"Count: {this.CurrentResource.GetAmount()} reagents";
        }

        public void UpdateReagents() {
            var count = this.CurrentResource.GetAmount();
            var reagents = this.CurrentResource.GetContents();

            if(reagents.Count != count || count == 0) {
                for(var i = 0; i < ReagentUIs.Count; i++) {
                    Destroy(ReagentUIs[i].gameObject);
                }

                ReagentUIs = new List<ReagentUI>();
            }

            for(var i = 0; i < count; i++) {
                if(ReagentUIs.Count < i + 1) {
                    Debug.Log("MAKING REAGENT UI");
                    var newPosition = new Vector2(ReagentAnchorStart.position.x, ReagentAnchorStart.position.y + ((i) * -0.7f));
                    var newReagentUI = Instantiate(ReagentUIPrefab, newPosition, Quaternion.identity, ReagentAnchorStart);
                    newReagentUI.Set(reagents[i]);
                    ReagentUIs.Add(newReagentUI);
                } else {
                    ReagentUI uiAtIndex = ReagentUIs[i];
                    uiAtIndex.Set(reagents[i]);
                }
            }
        }
    }
}