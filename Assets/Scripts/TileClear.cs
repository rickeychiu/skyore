using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClear : MonoBehaviour
{
    public Transform cam;
    public bool robotOnBoard;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        
    }

 
    void Update()
    {
        if (transform.position.x - cam.position.x <= -18)
        {
            Destroy(gameObject);
            if (robotOnBoard) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().sfx[1].volume = 0;
            }
        }
            
    }
}
