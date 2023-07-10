using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class playManager : MonoBehaviour
{
    const float JUDGEMENTTIME = 0.5f;
    public float tuneTiming = 0;

    // 노래를 재생하는데 사용할 소스, audioSource에 사용할 음악 클립
    AudioSource audioSource;
    public AudioClip musicClip;

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
    int noteCount = 1;

    // 곡이 진행중인지 나타내는 플래그
    bool isPlaying;

    Dictionary<int, string[]> Fracture_Ray = new Dictionary<int, string[]>()
    {
        // {노트 순서(key값) , new string[]{노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부}}

        {1, new string[]{"1.0", "(0,200,0)", "1", "false"}},
        {2, new string[]{"1.2", "(300,300,0)", "2", "false"}},
        {3, new string[]{"1.5", "(-100,0,0)", "3", "true"}},
        {4, new string[]{"1.5", "(500,0,0)", "4", "true"}},
        {5, new string[]{"2", "(700,200,0)", "5", "false"}},
        {6, null}
        
    };


    void Start()
    {
        // 동타 노트 생성을 위한 2번째 Update()
        StartCoroutine(CustomUpdate());

        // 음원 재생
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.Play();

        // 시작 시간 저장
        startTime = Time.time;

        // 곡이 진행중
        isPlaying = true;
        
    }

    void Update()
    {
        noteCreatTime = Time.time - startTime;

        if(isPlaying)
        {
            if(noteCreatTime >= float.Parse(Fracture_Ray[noteCount][0]) - JUDGEMENTTIME + tuneTiming && noteCount == int.Parse(Fracture_Ray[noteCount][2]))
            {
                Debug.Log(noteCreatTime);
                GameObject note = Instantiate(normalNote, StringToVector3(Fracture_Ray[noteCount][1]), normalNote.transform.rotation);
                note.transform.SetParent(notePanel.transform, false);
                noteCount += 1;
            }

            if(Fracture_Ray[noteCount] == null)
            {
                isPlaying = false;
            }
            
        }

    }

    IEnumerator CustomUpdate()
    {
        while (true)
        {
            noteCreatTime = Time.time - startTime;

            if(isPlaying)
            {
                // 동타일때만 노트 생성
                if(Fracture_Ray[noteCount][3] == "true")
                {
                    if(noteCreatTime >= float.Parse(Fracture_Ray[noteCount][0]) - JUDGEMENTTIME + tuneTiming && noteCount == int.Parse(Fracture_Ray[noteCount][2]))
                    {
                        Debug.Log(noteCreatTime);
                        GameObject note = Instantiate(normalNote, StringToVector3(Fracture_Ray[noteCount][1]), normalNote.transform.rotation);
                        note.transform.SetParent(notePanel.transform, false);
                        noteCount += 1;
                    }

                    if(Fracture_Ray[noteCount] == null)
                    {
                        isPlaying = false;
                    }
                }
                
            }

            // 다음 프레임까지 대기
            yield return null; 
        }
    }

      
    

    private Vector3 StringToVector3(string vectorString)
    {
        // 문자열에서 괄호 제거
        vectorString = vectorString.Replace("(", "").Replace(")", "");

        // 쉼표로 분리하여 문자열 배열로 변환
        string[] values = vectorString.Split(',');

        // 문자열 배열의 각 요소를 float로 변환하여 Vector3 생성
        float x = float.Parse(values[0]);
        float y = float.Parse(values[1]);
        float z = float.Parse(values[2]);

        return new Vector3(x, y, z);
    }

    
    
}
