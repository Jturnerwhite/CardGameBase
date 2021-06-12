using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventBoxType {
    Enemy,
    Camp,
    Item,
    Money
}

public class EventBox : MonoBehaviour
{
    public EventBoxType EventType;
    public Sprite[] Sprites;
    public Color[] Colors;

    public SpriteRenderer Icon;
    public SpriteRenderer Box;
    public SpriteRenderer Border1;
    public SpriteRenderer Border2;

    // Start is called before the first frame update
    void Awake()
    {
        Icon.sprite = Sprites[(int)EventType];
        Box.color = Colors[(int)EventType];
        var darkenedColor = new Color(Box.color.r - 20f, Box.color.g - 20f, Box.color.b - 20f, Box.color.a);
        Border1.color = darkenedColor;
        Border2.color = darkenedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
