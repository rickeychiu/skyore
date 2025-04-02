using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource music;
    public bool mutedMusic, mutedSFX;
    public Button SFX, Music;
    public Color greyed;

    public void UnmuteMuteMusic()
    {
        music.mute = !mutedMusic;
        mutedMusic = !mutedMusic;
        if (mutedMusic)
        {
            Music.image.color = greyed;
        } else 
        {
            Music.image.color = Color.white;
        }

    }

    public void UnmuteMuteSFX()
    {
        foreach (AudioSource AS in sfx) 
        {
            AS.mute = !mutedSFX;
        }
        mutedSFX = !mutedSFX;

        if (mutedSFX)
        {
            SFX.image.color = greyed;
        } else 
        {
            SFX.image.color = Color.white;
        }
    }

    public void PlaySound(AudioSource AS)
    {
        AS.Play(); 
    }
}
