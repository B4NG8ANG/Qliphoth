using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // songManager의 Init 함수에서 노래 정보를 저장
        songManager.Instance.Init();
        
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();   
    }
}
