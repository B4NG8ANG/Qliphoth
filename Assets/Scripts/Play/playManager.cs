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
    // private GameObject chartManager;

    // Main씬에서 Play씬으로 넘어온 정보들
    // 곡 ID, 곡 난이도
    public string songID;
    public string songDifficulty;

    // Play씬에 사용할 배경 이미지 (곡 이미지)
    public Image backgroundImage;

    // Play씬 밑에 보일 곡 이름과 난이도 텍스트 오브젝트
    public GameObject songNameText;
    public GameObject songDifficultyText;

    // 일시정지 패널 오브젝트
    public GameObject pausePanel;

    // 재시작 카운트다운 오브젝트
    public GameObject restartCountdownText;

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
    public GameObject canvas;

    // 밝기를 조절하는데 사용하는 이미지, 해당 이미지의 알파값을 조절할 Color 객체
    public GameObject brightSettingImage;
    Color brightSettingImageAlpha;

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

    // 여러 속성을 가진 노트들의 배열로 이루어진 채보
    // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}
    Note[] chart;

    // 노트의 총 갯수
    public int chartNoteCount;


    void Start()
    {   
        // mainManager 오브젝트를 찾음 
        mainManager = GameObject.Find("MainManager");

        // chartManager 오브젝트를 찾음 
        // chartManager = GameObject.Find("ChartManager");

        // 동타 노트 생성을 위한 2번째 Update()
        StartCoroutine(CustomUpdate());

        // 밝기 설정 이미지의 투명도를 조절하여 화면 밝기 조절
        brightSettingImageAlpha = brightSettingImage.GetComponent<Image>().color;
        brightSettingImageAlpha.a = float.Parse(PlayerPrefs.GetString("BrightAmount"));
        brightSettingImage.GetComponent<Image>().color = brightSettingImageAlpha;

        // mainManager에서 넘어온 곡 id를 이용하여 곡 정보를 불러와 Song 클래스 타입의 song 변수에 저장
        songID = mainManager.GetComponent<mainManager>().songID;
        Song song = songManager.Instance.getSongbyId(songID);

        // 음원 재생
        audioSource = GetComponent<AudioSource>();
        musicClip = Resources.Load<AudioClip>(song.songFileURL);
        audioSource.clip = musicClip;
        musicLength = musicClip.length;
        audioSource.Play();

        // 배경 화면 설정
        backgroundImage.sprite = Resources.Load<Sprite>(song.songImageFileURL);

        // 이번 곡에 사용할 채보를 chart에 저장하고 총 노트의 개수 계산
        songDifficulty = mainManager.GetComponent<mainManager>().songDifficulty;
        SetChart(song);
        chartNoteCount = chart.Length;

        // play 씬 밑에 곡 이름과 난이도 텍스트 설정 (난이도 표시 시 텍스트와 숫자 사이에 빈칸 추가)
        string spacedString = songDifficulty;

        for (int i = 0; i < spacedString.Length - 1; i++)
        {
            // 난이도 텍스트의 문자와 숫자 사이에 띄어쓰기 추가
            if ((char.IsLetter(spacedString[i]) && char.IsDigit(spacedString[i + 1])))
            {
                spacedString = spacedString.Insert(i + 1, " ");
            }
        }
        songNameText.GetComponent<Text>().text = song.songName;
        songDifficultyText.GetComponent<Text>().text = spacedString;

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
            if(noteCreatTime >= float.Parse(chart[noteCount].noteCreateTime) - JUDGEMENTTIME + tuneTiming && noteCount == int.Parse(chart[noteCount].noteNum))
            {
                Debug.Log(noteCreatTime);

                // 사전에 접근하여 노트의 종류 알아내기
                string noteType = chart[noteCount].noteType;

                // i) 노트의 종류가 일반 노트인 경우
                if(noteType == "normalNote")
                {
                    normalNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                    normalNotes[noteCount].SetActive(true);
                }

                // ii) 노트의 종류가 작은 일반 노트인 경우
                else if(noteType == "smallNormalNote")
                {
                    smallNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                    smallNormalNotes[noteCount].SetActive(true);
                }

                // iii) 노트의 종류가 큰 일반 노트인 경우
                else if(noteType == "bigNormalNote")
                {
                    bigNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                    bigNormalNotes[noteCount].SetActive(true);
                }

                // iiii) 노트의 종류가 롱 노트인 경우
                // 사전에 접근하여 알아낸 롱 노트 지속시간을 노트에 지정
                // 롱 노트 지속시간에 판정선이 줄어드는 0.5초를 더해줌
                else if(noteType == "longNote")
                {
                    longNotes[noteCount].GetComponent<LongNoteJudgementManager>().noteDeletingTime = float.Parse(chart[noteCount].longNoteDuration) + 0.5f;
                    longNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                    longNotes[noteCount].SetActive(true);
                }

                // iiiii) 노트의 종류가 슬라이드 노트인 경우
                else if(noteType == "slideNote")
                {
                    slideNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                    slideNotes[noteCount].SetActive(true);
                }

                noteCount += 1;

            }

            if(noteCount >= chart.Length)
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
                if(chart[noteCount].isNoteSameTime == "true")
                {
                    // 사전에 접근하여 알아낸 노트 생성 시간 - 0.5 + 싱크시간에 노트 생성
                    if(noteCreatTime >= float.Parse(chart[noteCount].noteCreateTime) - JUDGEMENTTIME + tuneTiming && noteCount == int.Parse(chart[noteCount].noteNum))
                    {
                        Debug.Log(noteCreatTime);

                        // 사전에 접근하여 노트의 종류 알아내기
                        string noteType = chart[noteCount].noteType;

                        // i) 노트의 종류가 일반 노트인 경우
                        if(noteType == "normalNote")
                        {
                            normalNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                            normalNotes[noteCount].SetActive(true);
                        }

                        // ii) 노트의 종류가 작은 일반 노트인 경우
                        else if(noteType == "smallNormalNote")
                        {
                            smallNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                            smallNormalNotes[noteCount].SetActive(true);
                        }

                        // iii) 노트의 종류가 큰 일반 노트인 경우
                        else if(noteType == "bigNormalNote")
                        {
                            bigNormalNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                            bigNormalNotes[noteCount].SetActive(true);
                        }

                        // iiii) 노트의 종류가 롱 노트인 경우
                        // 사전에 접근하여 알아낸 롱 노트 지속시간을 노트에 지정
                        // 롱 노트 지속시간에 판정선이 줄어드는 0.5초를 더해줌
                        else if(noteType == "longNote")
                        {
                            longNotes[noteCount].GetComponent<LongNoteJudgementManager>().noteDeletingTime = float.Parse(chart[noteCount].longNoteDuration) + 0.5f;
                            longNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                            longNotes[noteCount].SetActive(true);
                        }

                        // iiiii) 노트의 종류가 슬라이드 노트인 경우
                        else if(noteType == "slideNote")
                        {
                            slideNotes[noteCount].transform.position = StringToVector3(chart[noteCount].noteCreatePos);
                            slideNotes[noteCount].SetActive(true);
                        }

                        noteCount += 1;
                    }

                    if(noteCount >= chart.Length)
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
        if (alive == chartNoteCount)
        {
            score = 1000000;
        }

        scoreText.text = score.ToString("0000000");
    }


    // 노트 하나 당 점수를 계산
    public void CalculateScore()
    {
        scorePerNote = 1000000 / (chartNoteCount);
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

    // 곡의 id와 난이도를 이용하여 songManager에서 채보 정보를 가져와서 저장
    public void SetChart(Song song)
    {
        // 난이도가 Normal인 경우
        if(songDifficulty.Contains("Normal"))
        {
            chart = song.chartNormal;
        }
        // 난이도가 Hard 경우
        else if(songDifficulty.Contains("Hard"))
        {
            chart = song.chartHard;
        }
        // 난이도가 Death 경우
        else if(songDifficulty.Contains("Death"))
        {
            chart = song.chartDeath;
        }

    }


    public void ResultSceneChanger()
    {
        SceneChangeEffectManager.instance.FadeToScene("Result");
    }
    
}
