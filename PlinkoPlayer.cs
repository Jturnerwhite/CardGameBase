using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoPlayer : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    private DragAndDrop DragAndDrop;

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        DragAndDrop = GetComponent<DragAndDrop>();

        Rigidbody.bodyType = RigidbodyType2D.Static;
    }

    void Start() {
        DragAndDrop.IsDraggable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
