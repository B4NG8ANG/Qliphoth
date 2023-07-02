using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public AudioSource audioSource;
    private float startTime; // 스크립트 시작 시간

    // 노트 프리팹
    public GameObject bigNormalNote;
    public GameObject normalNote;
    public GameObject smallNormalNote;

    public GameObject notePanel;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();   

        // 시작 시간 저장
        startTime = Time.time; 

        // Invoke("spawnNote", 1f);
        // Invoke("spawnNote", 1f);
        // Invoke("spawnNote", 1f);
        // Invoke("spawnNote", 1f);
        // Invoke("spawnNote", 1f);
        


       
    }

    void Update()
    {
        // float noteCreatTime = Time.time - startTime;
        // Debug.Log(noteCreatTime);
        // if(noteCreatTime >= 1f)
        // {
        //     spawnNote();
        //     noteCreatTime -= 1f;
        // }
        
        
        //Instantiate(normalNote, new Vector3(0,0,0), Quaternion.identity);
        
        //Debug.Log("good");
    }

    void spawnNote()
    {
        GameObject note = Instantiate(normalNote, new Vector3(0,0,0), normalNote.transform.rotation);
        note.transform.SetParent(notePanel.transform, false);
        // 프리팹 오브젝트를 생성하고 변수에 할당합니다.
        // transform.position은 생성 위치를 나타내며, Quaternion.identity는 회전값을 기본 값으로 설정합니다.
        
        // 생성된 오브젝트에 대한 추가적인 설정이나 동작을 수행할 수 있습니다.
        // spawnedObject.GetComponent<YourComponent>().DoSomething();

        // 생성된 오브젝트를 필요에 따라 변수로 저장하거나 리스트에 추가할 수 있습니다.
        // 이후에 해당 오브젝트에 대한 조작이나 제어를 할 수 있습니다.
    }
    
}
