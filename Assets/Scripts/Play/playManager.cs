using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class playManager : MonoBehaviour
{
    // mainManager 스크립트를 참조하기 위한 변수
    private GameObject mainManager;

    // mainManager 스크립트를 참조하기 위한 변수
    private GameObject chartManager;

    // Main씬에서 Play씬으로 넘어온 정보들
    // 곡 이름, 곡 이미지 이름, 곡 작곡가 이름, 곡 난이도(B, L, D)
    public string songName;
    public string songArtImageName;
    public string songComposerName;
    public string songDifficulty;

    // Play씬에 사용할 배경 이미지 (곡 이미지)
    public Image backgroundImage;

    // 일시정지 패널 오브젝트
    public GameObject pausePanel;

    // 재시작 카운트다운 오브젝트
    public GameObject restartCountdownText;

    // Play씬에 사용할 채보 이름
    string chartName;

    // 판정선이 줄어드는 시간
    const float JUDGEMENTTIME = 0.5f;

    // 플레이어가 싱크 조절한 값
    public float tuneTiming = 0;

    // 노래를 재생하는데 사용할 소스, audioSource에 사용할 음악 클립, 음악의 길이
    AudioSource audioSource;
    AudioClip musicClip;
    float musicLength;

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

    // 게임, 곡이 진행 중인지 나타내는 플래그
    bool isPlaying;
    private bool isMusicFinished = false;

    // 오브젝트 풀링하기 위해 프리팹으로 만드는 노트 오브젝트의 배열
    GameObject[] normalNotes;
    GameObject[] smallNormalNotes;
    GameObject[] bigNormalNotes;
    GameObject[] longNotes;
    GameObject[] slideNotes;
    
    // 콤보, 콤보가 작성될 Text 오브젝트, 최대 콤보
    int combo = 0;
    public Text comboText;
    public int maxCombo = 0;

    // 총 점수, 노트 한 개당 점수, 점수가 작성될 Text 오브젝트
    public float score = 0;
    float scorePerNote;
    public Text scoreText;
    
    // alive, early, late, dead 판정을 받은 노트의 개수
    public int alive = 0;
    public int early = 0;
    public int late = 0;
    public int dead = 0;

    // 여러 속성을 가진 노트들로 이루어진 사전 형태의 채보
    // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}
    // 롱노트의 지속시간은 싱크에 맞는 시간 + 0.5초로 정해야 함
    Dictionary<int, string[]> chart = new Dictionary<int, string[]>(){};

    Dictionary<string, Dictionary<int, string[]>> chartContainer = new Dictionary<string, Dictionary<int, string[]>>();


    void Start()
    {
        // mainManager 오브젝트를 찾음 
        mainManager = GameObject.Find("MainManager");

        // chartManager 오브젝트를 찾음 
        chartManager = GameObject.Find("ChartManager");

        // 동타 노트 생성을 위한 2번째 Update()
        StartCoroutine(CustomUpdate());

        // 음원 재생
        audioSource = GetComponent<AudioSource>();
        songName = mainManager.GetComponent<mainManager>().songName;
        musicClip = Resources.Load<AudioClip>("Audio/PlayableSong/" + songName);
        audioSource.clip = musicClip;
        musicLength = musicClip.length;
        audioSource.Play();

        // 배경 화면 설정
        songArtImageName = mainManager.GetComponent<mainManager>().songArtImageName;
        backgroundImage.sprite = Resources.Load<Sprite>("Play/SongArt/" + songArtImageName);

        // 작곡가 이름 저장
        songComposerName = mainManager.GetComponent<mainManager>().songComposerName;

        // 이번 곡에 사용할 채보를 chart에 저장
        songDifficulty = mainManager.GetComponent<mainManager>().songDifficulty;
        SetChart();

        // 이번 곡의 노트 하나당 점수 계산
        CalculateScore();

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

        Time.timeScale = 0f;
        restartCountdownText.SetActive(true);
        
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
                // 롱 노트 지속시간에 판정선이 줄어드는 0.5초를 더해줌
                else if(noteType == "longNote")
                {
                    longNotes[noteCount].GetComponent<LongNoteJudgementManager>().noteDeletingTime = float.Parse(chart[noteCount][5]) + 0.5f;
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

        // 노래 및 채보가 끝나면 호출
        if(noteCreatTime >= musicLength && !isMusicFinished)
        {
            isMusicFinished = true;
            Invoke("ResultSceneChanger", 3.0f);
        }
        

        // 게임이 멈춘 상태라면 음악을 일시정지하고, 진행 중인 상태라면 음악을 재생
        if (Time.timeScale == 0f)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
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
                        // 롱 노트 지속시간에 판정선이 줄어드는 0.5초를 더해줌
                        else if(noteType == "longNote")
                        {
                            longNotes[noteCount].GetComponent<LongNoteJudgementManager>().noteDeletingTime = float.Parse(chart[noteCount][5]) + 0.5f;
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

        if(combo > maxCombo)
        {
            maxCombo = combo;
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
            score += Mathf.Floor(scorePerNote / 2);
        }

        // 반올림 등에 의해 점수가 100만점이 넘어간 경우, 점수를 100만점으로 취급
        if (score >= 1000000)
        {
            score = 1000000;
        }

        // All alive일 때 점수를 100만점으로 취급
        if (alive == chart.Count - 1)
        {
            score = 1000000;
        }

        scoreText.text = score.ToString("0000000");
    }


    // 노트 하나 당 점수를 계산
    public void CalculateScore()
    {
        scorePerNote = 1000000 / (chart.Count - 1);
        scorePerNote = Mathf.Floor(scorePerNote);
        Debug.Log("노트당 점수" + scorePerNote);
    }

    // 판정의 개수를 각각 셈
    public void CountJudgement(string judgement)
    {
        if(judgement == "alive")
        {
            alive = alive + 1;
        }
        else if(judgement == "early")
        {
            early = early + 1;
        }
        else if(judgement == "late")
        {
            late = late + 1;
        }
        else if(judgement == "dead")
        {
            dead = dead + 1;
        }
    }

    public void SetChart()
    {
        // 곡 이름과 난이도를 조합해서 차트 이름에 해당하는 새 문자열 생성
        string replaceSongName = songName.Replace(" ", "_");
        replaceSongName += "_";
        chartName = replaceSongName + songDifficulty;

        // chartManager의 chartContainer 사전을 가져와서 저장
        chartContainer = chartManager.GetComponent<chartManager>().chartContainer;

        Debug.Log(chartName);

        if (chartContainer.ContainsKey(chartName))
        {
            chart = chartContainer[chartName];

        }

    }


    public void ResultSceneChanger()
    {
        SceneChangeEffectManager.instance.FadeToScene("Result");
    }
    
}
