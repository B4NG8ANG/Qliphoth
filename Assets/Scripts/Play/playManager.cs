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
    public GameObject longNote;
    public GameObject slideNote;

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



        else if(noteCreatTime >= 1.13f && noteCount == 3)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-250,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 1.3f && noteCount == 4)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-500,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }


        
        else if(noteCreatTime >= 1.5f && noteCount == 5)
        {
            GameObject note = Instantiate(normalNote, new Vector3(600,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }



        else if(noteCreatTime >= 1.8f && noteCount == 6)
        {
            GameObject note = Instantiate(normalNote, new Vector3(0,-300,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 1.9f && noteCount == 7)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-250,-300,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 2.0f && noteCount == 8)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-500,-300,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 2.6f && noteCount == 9)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-250,100,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 2.63f && noteCount == 10)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-500,100,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }



      
    }
    
}
