using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public AudioSource audioSource;

    // 스크립트 시작 시간
    private float startTime; 

    // 노트 프리팹
    public GameObject bigNormalNote;
    public GameObject normalNote;
    public GameObject smallNormalNote;

    // 노트가 보일 패널
    public GameObject notePanel;

    // 노트 생성 시간, 생성 노트 개수
    float noteCreatTime;
    int noteCount = 0;


    void Start()
    {
        // 음원 재생
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();   

        // 시작 시간 저장
        startTime = Time.time; 
        
    }

    void Update()
    {
        FractureRay();
    }

    void FractureRay()
    {
        noteCreatTime = Time.time - startTime;
        
        if(noteCreatTime >= 0.6f && noteCount == 0)
        {
            GameObject note = Instantiate(normalNote, new Vector3(0,0,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 0.7f && noteCount == 1)
        {
            GameObject note = Instantiate(normalNote, new Vector3(250,0,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 0.8f && noteCount == 2)
        {
            GameObject note = Instantiate(normalNote, new Vector3(500,0,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

      
    }
    
}
