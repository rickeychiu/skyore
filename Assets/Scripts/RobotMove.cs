using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    public float x;
    public Rigidbody2D rb;
    public AudioManager am;
    
    void Start()
    {
        x = speed;
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.sfx[1].volume = 0.02f;
        transform.parent.GetComponent<TileClear>().robotOnBoard = true;
    }
    void Update()
    {
        if (transform.localPosition.x < minX) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            x = speed;
        } else if (transform.localPosition.x > maxX) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            x = -speed;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(x, 0);
    }
}
