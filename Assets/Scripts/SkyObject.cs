using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyObject : MonoBehaviour
{
    public Transform boundary;
    public bool travelRight;
    public Rigidbody2D rb;
    public float vel;
    void FixedUpdate()
    {
        rb.velocity = new Vector2(vel, 0);
        if (travelRight)
        {
            if (transform.position.x > boundary.position.x)
                Destroy(gameObject);
        } 
        else 
        {
            if (transform.position.x < boundary.position.x)
                Destroy(gameObject);
        }
    }
}
