using System.Collections;
using System.Collections.Generic;
using Characters.Classes;
using UnityEngine;

public class PlinkoPlayer : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    private DragAndDrop DragAndDrop;

    public SpriteRenderer[] ClassSpritePrefabs;

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        DragAndDrop = GetComponent<DragAndDrop>();
    }

    void Start() {
        Rigidbody.bodyType = RigidbodyType2D.Static;
        DragAndDrop.IsDraggable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(CharacterClass type) {
        var match = ClassSpritePrefabs[(int)type];
        var newInst = Instantiate(match);
        newInst.transform.SetParent(transform);
        newInst.transform.localPosition = new Vector3(-0.025f, 0f, -1f);
        newInst.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
    }

    public void OnDrag() {
        Debug.Log("Player drag started");
    }

    public void OnDrop() {
        Debug.Log("Player dropped");
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        DragAndDrop.IsDraggable = false;
    }
}
