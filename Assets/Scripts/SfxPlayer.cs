using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    public void Button()
    {
        src.clip = sfx1;
        src.Play();
    }
}
