using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public BoxCollider2D box1, box2;
    public AudioManager am;

    void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void BatteryOff() 
    {
        box1.enabled = false;
        box2.enabled = false;
        am.sfx[4].mute = true;
    }

    public void BatteryOn() 
    {
        am.sfx[4].mute = false;
        box1.enabled = true;
        box1.enabled = true;
        am.PlaySound(am.sfx[4]);
    }
}
