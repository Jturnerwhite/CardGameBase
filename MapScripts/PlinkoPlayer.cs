using System.Collections;
using System.Collections.Generic;
using Characters.Classes;
using UnityEngine;

public class PlinkoPlayer : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    private DragAndDrop DragAndDrop;
    private Vector3 StartPos;
    private Vector3 ThresholdPos;

    public SpriteRenderer[] ClassSpritePrefabs;

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        DragAndDrop = GetComponent<DragAndDrop>();
    }

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(CharacterClass type, Vector3 initialPosition, Vector3 thresholdPosition, bool enableDragDrop = true) {
        var match = ClassSpritePrefabs[(int)type];
        var newInst = Instantiate(match);
        newInst.transform.SetParent(transform);
        newInst.transform.localPosition = new Vector3(-0.025f, 0f, -1f);
        newInst.transform.localScale = new Vector3(0.25f, 0.25f, 1f);

        if(enableDragDrop) {
            Rigidbody.bodyType = RigidbodyType2D.Static;
            DragAndDrop.IsDraggable = true;
        } else {
            Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            DragAndDrop.IsDraggable = false;
        }

        StartPos = initialPosition;
        ThresholdPos = thresholdPosition;
        DragAndDrop.ThresholdPosY = ThresholdPos.y;
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
