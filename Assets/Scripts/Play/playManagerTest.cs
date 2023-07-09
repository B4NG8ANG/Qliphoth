using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManagerTest : MonoBehaviour
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
        CytusII();

    }

    void CytusII()
    {
        noteCreatTime = Time.time - startTime;
        
        if(noteCreatTime >= 4.9f && noteCount == 0)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(-400,-200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 5.2f && noteCount == 1)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-300,0,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 5.7f && noteCount == 2)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(0,100,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 6f && noteCount == 3)
        {
            GameObject note = Instantiate(normalNote, new Vector3(250,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 6.3f && noteCount == 4)
        {
            GameObject note = Instantiate(normalNote, new Vector3(500,250,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }



        else if(noteCreatTime >= 7.9f && noteCount == 5)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(400,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }
        
        else if(noteCreatTime >= 8.1f && noteCount == 6)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(600,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }




        else if(noteCreatTime >= 8.4f && noteCount == 7)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(-400,-200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 8.7f && noteCount == 8)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-300,0,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 9.2f && noteCount == 9)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(0,100,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 9.5f && noteCount == 10)
        {
            GameObject note = Instantiate(normalNote, new Vector3(250,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 9.8f && noteCount == 11)
        {
            GameObject note = Instantiate(normalNote, new Vector3(500,250,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }


        else if(noteCreatTime >= 11.1f && noteCount == 12)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(0,100,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 11.4f && noteCount == 13)
        {
            GameObject note = Instantiate(normalNote, new Vector3(250,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 11.7f && noteCount == 14)
        {
            GameObject note = Instantiate(normalNote, new Vector3(500,250,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }



        else if(noteCreatTime >= 12.1f && noteCount == 15)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(-400,-200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 12.3f && noteCount == 16)
        {
            GameObject note = Instantiate(normalNote, new Vector3(-300,0,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 12.8f && noteCount == 17)
        {
            GameObject note = Instantiate(smallNormalNote, new Vector3(0,100,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 13.1f && noteCount == 18)
        {
            GameObject note = Instantiate(normalNote, new Vector3(250,200,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }

        else if(noteCreatTime >= 13.4f && noteCount == 19)
        {
            GameObject note = Instantiate(normalNote, new Vector3(500,250,0), normalNote.transform.rotation);
            note.transform.SetParent(notePanel.transform, false);
            noteCount += 1;
            return;
        }
        
    }
    
}
