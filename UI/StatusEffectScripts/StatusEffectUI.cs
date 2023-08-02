using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StatusEffects;

public class StatusEffectUI : MonoBehaviour
{
    public StatusEffect StatusEffect;

    public Text Count;

    public void Init(StatusEffect statusEffect) {
        StatusEffect = statusEffect;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StatusEffect != null) {
            Count.text = $"{StatusEffect.Name[0]}:{StatusEffect.Count}";
        }
    }
}
