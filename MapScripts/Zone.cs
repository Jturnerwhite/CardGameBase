using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ZoneEvent : UnityEvent<Zone> {}

public class Zone : MonoBehaviour
{
    //public Receiver Receiver;

    public ZoneEvent TriggerEvent;

    public ZoneEvent StayEvent;
    public float StayThreshold;

    private float StayDurationTimer;
    private bool Entered;

    // Start is called before the first frame update
    void Start()
    {
        //Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Entered) {
            StayDurationTimer += Time.fixedDeltaTime;

            if(StayDurationTimer >= StayThreshold) {
                Entered = false;
                StayEvent.Invoke(this);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //TriggerEvent.Invoke(this);

        StayDurationTimer = 0.0f;
        Entered = true;
    }
}
