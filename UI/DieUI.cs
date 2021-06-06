using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Resources;
using UI;

public class DieUI : ResourceUI {
    public Text Text;
    public SpriteRenderer Sprite;

    private bool IsDisabled;
    private Resource Resource;

    public override void Init(Resource resource, Transform parent, Vector2? position) {
        transform.SetParent(parent, false);

        if(position.HasValue) {
            transform.position = position.Value;
        } else {
            transform.localPosition = new Vector2(0, 0);
        }

        Resource = resource;
        IsDisabled = false;
        Set(Resource.Amount, resource.Color);
    }


    public override void UpdateValue() {
        if(Resource == null) {
            return;
        }

        int value = Resource.Amount;
        Color color = Resource.Color;

        if(!IsDisabled && Resource.IsDisabled) {
            color = Color.gray;
        }

        IsDisabled = Resource.IsDisabled;
        Set(value, color);
    }

    public void Set(int value, Color color) {
        Text.text = value.ToString();
        Sprite.color = color;
    }
}
