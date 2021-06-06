using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Resources;

namespace UI {
    public class ResourceDice : ResourceUI {

        public DieUI DiePrefab;
        public Transform[] DiceSlots;

        public List<DieUI> Dice { get; set; }

        private Resource Resource { get; set; }

        public override void Init(Resource resource, Transform parent, Vector2? position) {
            transform.SetParent(parent, false);

            if(position.HasValue) {
                transform.position = position.Value;
            } else {
                new Vector2((parent.localPosition.x), (parent.localPosition.y + 1.5f));
            }

            ClearDice();
            Resource = resource;

            Resource[] dataDice = resource.GetSubResources();
            MakeDice(dataDice);
        }

        void FixedUpdate() {
            UpdateValue();
        }

        public override void UpdateValue() {
            if(Resource != null && Dice != null) {
                var dataDice = Resource.GetSubResources();
                if(Dice.Count != dataDice.Length) {
                    ClearDice();
                    MakeDice(dataDice);
                }

                foreach(var die in Dice) {
                    die.UpdateValue();
                }
            }
        }

        public void ClearDice() {
            if(Dice != null) {
                foreach(var die in Dice) {
                    Destroy(die.gameObject);
                }
            }

            Dice = new List<DieUI>();
        }

        public void MakeDice(Resource[] dataDice) {
            for(int i = 0; i < dataDice.Length; i++) {
                // make each die
                Resource dataDie = dataDice[i];
                if(dataDie != null) {
                    var newDie = Instantiate(DiePrefab) as DieUI;
                    Transform matchingSlot = DiceSlots[i];
                    newDie.Init(dataDice[i], matchingSlot, null);
                    Dice.Add(newDie);
                }
            }
        }
    }
}
