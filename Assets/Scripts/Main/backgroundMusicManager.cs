using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundMusicManager : MonoBehaviour
{
    // 음원을 트는 컴포넌트와 배경 음악의 이름, 곡 이름 텍스트 오브젝트
    private AudioSource audioSource;
    private string backgroundMusic;
    public GameObject songNameObject;

    // 곡 선택창 패널
    public GameObject songSelectPanel;

    // 곡 미리듣기가 재생 중인지 나타내는 플래그
    bool isPlaying = false;

    void Start()
    {
        backgroundMusic = "Main Background Music";
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/Background/Main/" + backgroundMusic);
        audioSource.Play();
        
    }


    void Update()
    {
        if(songSelectPanel != null)
        {
            if(songSelectPanel.activeSelf && !isPlaying)
            {
                backgroundMusic = songNameObject.GetComponent<Text>().text;
                audioSource.clip = Resources.Load<AudioClip>("Audio/PlayableSong/" + backgroundMusic);
                audioSource.Play();
                isPlaying = true;
            }
            else if(!songSelectPanel.activeSelf && isPlaying)
            {
                isPlaying = false;
                backgroundMusic = "Main Background Music";
                audioSource.clip = Resources.Load<AudioClip>("Audio/Background/Main/" + backgroundMusic);
                audioSource.Play();
            }
        }
        
    }
}
