using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class playManager : MonoBehaviour
{
    // 판정선이 줄어드는 시간
    const float JUDGEMENTTIME = 0.5f;

    // 플레이어가 싱크 조절할 값
    public float tuneTiming = 0;

    // 노래를 재생하는데 사용할 소스, audioSource에 사용할 음악 클립
    AudioSource audioSource;
    public AudioClip musicClip;

    // 스크립트 시작 시각
    private float startTime; 

    // 노트 프리팹
    public GameObject bigNormalNote;
    public GameObject normalNote;
    public GameObject smallNormalNote;
    public GameObject longNote;
    public GameObject slideNote;

    // 노트가 보일 패널
    public GameObject notePanel;

    // 노트 생성 시간, 생성 노트 개수(노트 번호)
    float noteCreatTime;
    int noteCount = 0;

    // 곡이 진행중인지 나타내는 플래그
    bool isPlaying;

    // 오브젝트 풀링하기 위해 프리팹으로 만드는 노트 오브젝트의 배열
    GameObject[] normalNotes;
    GameObject[] smallNormalNotes;
    GameObject[] bigNormalNotes;
    GameObject[] longNotes;
    GameObject[] slideNotes;
    
    // 콤보 및 콤보가 작성될 Text 오브젝트
    int combo = 0;
    public Text comboText;

    // 총 점수, 노트 한 개당 점수, 점수가 작성될 Text 오브젝트
    double score = 0;
    double scorePerNote;
    public Text scoreText;

    

    // 여러 속성을 가진 노트들로 이루어진 사전 형태의 채보
    // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}
    Dictionary<int, string[]> chart = new Dictionary<int, string[]>(){};

    // Fracture Ray
    Dictionary<int, string[]> Fracture_Ray = new Dictionary<int, string[]>()
    {
        // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}

        // {0, new string[]{"normalNote", "1.0", "(100,300,0)", "0", "false", ""}},
        // {1, new string[]{"smallNormalNote", "2.0", "(300,300,0)", "1", "false", ""}},
        // {2, new string[]{"slideNote", "3.0", "(100,500,0)", "2", "false", ""}},
        // {3, new string[]{"slideNote", "4.0", "(500,500,0)", "3", "false", ""}},
        // {4, new string[]{"longNote", "5.0", "(600,500,0)", "4", "false", "1.0"}},
        // {5, new string[]{"bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""}},
        // {6, new string[]{"normalNote", "7.0", "(800,200,0)", "6", "false", ""}},
        // {7, new string[]{"normalNote", "8.0", "(900,200,0)", "7", "false", ""}},
        // {8, new string[]{"normalNote", "9.0", "(900,300,0)", "8", "false", ""}},
        // {9, new string[]{"normalNote", "10.0", "(700,400,0)", "9", "false", ""}},
        // {10, new string[]{"slideNote", "11.0", "(800,500,0)", "10", "false", ""}},
        // {11, new string[]{"slideNote", "11.1", "(900,600,0)", "11", "false", ""}},
        // {12, new string[]{"slideNote", "11.2", "(1000,700,0)", "12", "false", ""}},
        // {13, null}

        {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        {1, new string[]{"longNote", "2.0", "(700,700,0)", "1", "false", "2.0"}},
        {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        {3, null}
        
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

        // 곡이 진행중인지 확인하는 플래그
        isPlaying = true;

        // 오브젝트 풀링 하기 위해 프리팹을 이용하여 노트들을 미리 생성하고 배열로 저장
        normalNotes = new GameObject[500];
        for(int i = 0; i < 500; i++)
        {
            GameObject normalNotesGameObject= Instantiate(normalNote);
            normalNotes[i] = normalNotesGameObject;
            normalNotesGameObject.transform.SetParent(notePanel.transform, false);
            normalNotesGameObject.SetActive(false);
        }
        
        smallNormalNotes = new GameObject[500];
        for(int i = 0; i < 500; i++)
        {
            GameObject smallNormalNotesGameObject= Instantiate(smallNormalNote);
            smallNormalNotes[i] = smallNormalNotesGameObject;
            smallNormalNotesGameObject.transform.SetParent(notePanel.transform, false);
            smallNormalNotesGameObject.SetActive(false);
        }

        bigNormalNotes = new GameObject[500];
        for(int i = 0; i < 500; i++)
        {
            GameObject bigNormalNotesGameObject= Instantiate(bigNormalNote);
            bigNormalNotes[i] = bigNormalNotesGameObject;
            bigNormalNotesGameObject.transform.SetParent(notePanel.transform, false);
            bigNormalNotesGameObject.SetActive(false);
        }

        longNotes = new GameObject[500];
        for(int i = 0; i < 500; i++)
        {
            GameObject longNotesGameObject= Instantiate(longNote);
            longNotes[i] = longNotesGameObject;
            longNotesGameObject.transform.SetParent(notePanel.transform, false);
            longNotesGameObject.SetActive(false);
        }

        slideNotes = new GameObject[500];
        for(int i = 0; i < 500; i++)
        {
            GameObject slideNotesGameObject= Instantiate(slideNote);
            slideNotes[i] = slideNotesGameObject;
            slideNotesGameObject.transform.SetParent(notePanel.transform, false);
            slideNotesGameObject.SetActive(false);
        }

        // 이번 곡에 사용할 채보를 chart에 저장
        chart = Fracture_Ray;

        CalculateScore();


    }

    void Update()
    {
        noteCreatTime = Time.time - startTime;

        if(isPlaying)
        {
            // 사전에 접근하여 알아낸 노트 생성 시간 - 0.5 + 싱크시간에 노트 생성
            if(noteCreatTime >= float.Parse(chart[noteCount][1]) - JUDGEMENTTIME + tuneTiming && noteCount == int.Parse(chart[noteCount][3]))
            {
                Debug.Log(noteCreatTime);

                // 사전에 접근하여 노트의 종류 알아내기
                string noteType = chart[noteCount][0];

                // i) 노트의 종류가 일반 노트인 경우
                if(noteType == "normalNote")
                {
                    normalNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                    normalNotes[noteCount].SetActive(true);
                }

                // ii) 노트의 종류가 작은 일반 노트인 경우
                else if(noteType == "smallNormalNote")
                {
                    smallNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                    smallNormalNotes[noteCount].SetActive(true);
                }

                // iii) 노트의 종류가 큰 일반 노트인 경우
                else if(noteType == "bigNormalNote")
                {
                    bigNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                    bigNormalNotes[noteCount].SetActive(true);
                }

                // iiii) 노트의 종류가 롱 노트인 경우
                // 사전에 접근하여 알아낸 롱 노트 지속시간을 노트에 지정
                else if(noteType == "longNote")
                {
                    longNotes[noteCount].GetComponent<LongNoteJudgementManager>().noteDeletingTime = float.Parse(chart[noteCount][5]);
                    longNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                    longNotes[noteCount].SetActive(true);
                }

                // iiiii) 노트의 종류가 슬라이드 노트인 경우
                else if(noteType == "slideNote")
                {
                    slideNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                    slideNotes[noteCount].SetActive(true);
                }

                noteCount += 1;

            }

            if(chart[noteCount] == null)
            {
                isPlaying = false;
            }
            
        }

        else
        {
            // 노래 끝나고 처리할 작업
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
                if(chart[noteCount][4] == "true")
                {
                    // 사전에 접근하여 알아낸 노트 생성 시간 - 0.5 + 싱크시간에 노트 생성
                    if(noteCreatTime >= float.Parse(chart[noteCount][1]) - JUDGEMENTTIME + tuneTiming && noteCount == int.Parse(chart[noteCount][3]))
                    {
                        Debug.Log(noteCreatTime);

                        // 사전에 접근하여 노트의 종류 알아내기
                        string noteType = chart[noteCount][0];

                        // i) 노트의 종류가 일반 노트인 경우
                        if(noteType == "normalNote")
                        {
                            normalNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                            normalNotes[noteCount].SetActive(true);
                        }

                        // ii) 노트의 종류가 작은 일반 노트인 경우
                        else if(noteType == "smallNormalNote")
                        {
                            smallNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                            smallNormalNotes[noteCount].SetActive(true);
                        }

                        // iii) 노트의 종류가 큰 일반 노트인 경우
                        else if(noteType == "bigNormalNote")
                        {
                            bigNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                            bigNormalNotes[noteCount].SetActive(true);
                        }

                        // iiii) 노트의 종류가 롱 노트인 경우
                        // 사전에 접근하여 알아낸 롱 노트 지속시간을 노트에 지정
                        else if(noteType == "longNote")
                        {
                            longNotes[noteCount].GetComponent<LongNoteJudgementManager>().noteDeletingTime = float.Parse(chart[noteCount][5]);
                            longNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                            longNotes[noteCount].SetActive(true);
                        }

                        // iiiii) 노트의 종류가 슬라이드 노트인 경우
                        else if(noteType == "slideNote")
                        {
                            slideNotes[noteCount].transform.position = StringToVector3(chart[noteCount][2]);
                            slideNotes[noteCount].SetActive(true);
                        }

                        noteCount += 1;
                    }

                    if(chart[noteCount] == null)
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

    // 콤보를 추가하고, 초기화 하는 함수
    public void AddCombo(bool notDead)
    {
        if(notDead)
        {
            combo += 1;
        }
        else if(!notDead)
        {
            combo = 0;
        }

        if(combo >= 2)
        {
            comboText.text = combo.ToString();
        }
        else if(combo < 2)
        {
            comboText.text = "";
        }
    }
    
    public void AddScore(bool notDead)
    {
        if(notDead)
        {
            score += scorePerNote;
        }
        else if(!notDead)
        {
            score += scorePerNote / 2;
        }

        score = Math.Floor(score);

        // 반올림 등에 의해 점수가 100만점이 넘어간 경우, 점수를 100만점으로 취급
        if (score >= 1000000)
        {
            score = 1000000;
        }
        
        // 올얼라이브에 대해 점수를 정확하게 해주는 함수 호출

        scoreText.text = score.ToString();
    }

    public void CalculateScore()
    {
        scorePerNote = 1000000 / (chart.Count - 1);
        Debug.Log(scorePerNote);
    }
    
}
