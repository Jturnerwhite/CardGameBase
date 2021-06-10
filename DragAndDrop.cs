using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragAndDrop : MonoBehaviour
{
    public UnityEvent Drag;
    public UnityEvent Drop;

    public bool IsDraggable;

    private bool isDragging;

    public void OnMouseDown()
    {
        if(IsDraggable) {
            isDragging = true;
            Drag.Invoke();
        }
    }

    public void OnMouseUp()
    {
        if(IsDraggable && isDragging) {
            isDragging = false;
            Drop.Invoke();
        }
    }

    void Update()
    {
        if (IsDraggable && isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}