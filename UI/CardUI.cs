using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cards;

public class CardUI : MonoBehaviour
{

    public Canvas Canvas;
    public Text Cost;
    public SpriteRenderer CostDisplay;
    public Text Name;
    public Text Description;

    public Card card;

    public void Initialize(Card card) {
        this.card = card;
        Cost.text = card.Cost.ToString();
        Name.text = card.Name;
        Description.text = card.Description;
    }

    void Awake() {
        this.Canvas.worldCamera = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
