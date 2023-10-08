using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound1;



    public void OnButtonClickMakeSound()
    {
        audioSource.clip = clickSound1;
        audioSource.Play();
        Debug.Log("good");
    }
}
