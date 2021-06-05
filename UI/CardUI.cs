using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cards;

namespace UI {
    public class CardUI : MonoBehaviour {

        public Canvas Canvas;
        public Text Cost;
        public SpriteRenderer CostDisplay;
        public SpriteRenderer Border;
        public Text Name;
        public Text Description;

        public Card card;
        private bool isSelected;

        public void Initialize(Card card) {
            this.card = card;
        }

        void Awake() {
            this.Canvas.worldCamera = Camera.main;
        }

        public void Clicked() {
            var EventManager = Camera.main.GetComponent<EventManager>();
            if(EventManager != null) {
                EventManager.CardClicked(this);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Description.text = card.Description;
            Cost.text = card.Cost.ToString();
            Name.text = card.Name;
            Description.text = card.Description;
        }

        public void ToggleHighlight(bool? isSelected = null) {
            this.isSelected = (isSelected != null) ? isSelected.Value : !this.isSelected;

            if(this.isSelected) {
                Border.color = Color.yellow;
            } else {
                Border.color = Color.white;
            }
        }

        public void Discard() {
            Debug.Log("This card was deleted!");
            Destroy(gameObject);
        }
    }
}
