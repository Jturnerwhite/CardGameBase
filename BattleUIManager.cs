using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Cards;
using Characters;

public class BattleUIManager : MonoBehaviour {

    public CardUI CardUIPrefab;
    public Transform CardDockPrefab;

    private Transform CardDock { get; set; }
    private List<CardUI> currentHand { get; set; }

    void Awake() {
        currentHand = new List<CardUI>();
        CardDock = Instantiate(CardDockPrefab, new Vector3(0, -4.5f), Quaternion.identity);
        SetCards(new List<Card>() {
            new Strike(),
            new HorizonStrike(),
            new Respite(),
            new ViciousVigor()
        });
    }

    public void SetCards(List<Card> cards) {
        float x = -4.0f;
        float y = -3.0f;
        float increment = 2.6f;

        foreach(var card in cards) {
            currentHand.Add(GenerateCardUI(card, new Vector3(x, y)));
            x += increment;
        }
    }

    public CardUI GenerateCardUI(Card data, Vector3 pos) {
        CardUI newCard = Instantiate(CardUIPrefab, pos, Quaternion.identity, CardDock);
        newCard.Initialize(data);

        return newCard;
    }
}