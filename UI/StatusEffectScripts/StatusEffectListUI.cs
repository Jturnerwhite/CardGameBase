using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatusEffects;

public class StatusEffectListUI : MonoBehaviour
{
    public StatusEffectUI StatusEffectUIPrefab;

    public List<StatusEffect> StatusEffects;
    public List<StatusEffectUI> StatusEffectUIs;

    public void Init(List<StatusEffect> statusEffects) {
        StatusEffects = statusEffects;
        StatusEffectUIs = new List<StatusEffectUI>();
        
        if(StatusEffects.Count > 0) {
            MakeAllStatusEffectUIs();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StatusEffects.Count != StatusEffectUIs.Count) {
            Clear();
            MakeAllStatusEffectUIs();
        }
    }

    public void MakeAllStatusEffectUIs() {
        for(var i = 0; i < StatusEffects.Count; i++) {
            AddStatusEffectUI(StatusEffects[i], i);
        }
    }

    public void AddStatusEffectUI(StatusEffect effect, int index) {
        Vector2 newPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        newPosition.x += (index * 0.25f);
        StatusEffectUI newEffectUI = Instantiate(StatusEffectUIPrefab, newPosition, Quaternion.identity);
        newEffectUI.Init(effect);
        StatusEffectUIs.Add(newEffectUI);
    }

    public void Clear() {
        if(StatusEffectUIs != null) {
            foreach(var effectUI in StatusEffectUIs) {
                Destroy(effectUI.gameObject);
            }
        }

        StatusEffectUIs = new List<StatusEffectUI>();
    }
}
