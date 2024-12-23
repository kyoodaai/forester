using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer
{
    public static void FootSteps(AudioClip clip, AudioSource foot)
    {
        if (!foot.isPlaying)
        {
            foot.clip = clip;
            foot.PlayOneShot(clip);
        }
    }
}
