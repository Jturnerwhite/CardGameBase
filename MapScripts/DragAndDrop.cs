using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragAndDrop : MonoBehaviour
{
    public UnityEvent Drag;
    public UnityEvent Drop;

    public bool IsDraggable;
    public float ThresholdPosY;

    private bool isDragging;
    private float playerTokenRadius = 0.4f;

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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsDraggable && 
            isDragging && 
            (mousePosition.x < 5 - playerTokenRadius) && 
            (mousePosition.x > -5 + playerTokenRadius) && 
            (mousePosition.y < 4 - playerTokenRadius) &&
            (mousePosition.y > ThresholdPosY + playerTokenRadius)) {

            Vector2 newPost = mousePosition - transform.position;
            transform.Translate(newPost);
        }
    }
}