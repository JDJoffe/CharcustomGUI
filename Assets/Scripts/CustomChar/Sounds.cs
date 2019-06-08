using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Sounds : MonoBehaviour
{
    public AudioClip button;
    public AudioSource buttonSource;

    public void Button()
    {
        buttonSource.clip = button;
        buttonSource.Play();
    }
}
