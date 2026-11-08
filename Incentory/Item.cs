using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public InvSObj invSObj;
    public int amount;
    public float Speed;
    public Rigidbody rb;
    public int Point;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb != null)
        { 
            rb.linearVelocity = transform.up * Speed; 
        }
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Graund")
        {
            Speed = 0f;
            rb.isKinematic = true;
        }
    }
}
