using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindOfChange : MonoBehaviour
{
    public float WindStrength;
    public bool FlowLeft;
    public float Interval;

    private Rigidbody2D Rigidbody;

    private Vector2 Left = new Vector2(-1, 0);
    private Vector2 Right = new Vector2(1, 0);

    private float Timer;

    void Awake()
    {
        var RNG = new System.Random(DateTime.Now.Millisecond);
        FlowLeft = (RNG.Next(-5, 5) > 0);

        Rigidbody = GetComponent<Rigidbody2D>();
        Timer = 0.0f;
    }

    void FixedUpdate()
    {
        Timer += Time.fixedDeltaTime;

        if(Timer > Interval) {
            ChangeDirection();
            Timer = 0.0f;
        }

        Rigidbody.AddForce(((FlowLeft) ? Left : Right) * WindStrength, ForceMode2D.Impulse);
    }

    public void ChangeDirection() {
        FlowLeft = !FlowLeft;
    }
}
