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

        // AuthManager의 Init으로 초기화
        AuthManager.Instance.init();
        
        // 타이틀 씬 배경 음악 실행 
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();   
    }
}
