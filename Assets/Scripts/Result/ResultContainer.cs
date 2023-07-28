using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultContainer : MonoBehaviour
{
    // ResultContainer 객체의 인스턴스 생성
    public static ResultContainer Instance;

    // playManager 스크립트를 참조하기 위한 변수
    private GameObject playManager;

    // 결과창에 보일 곡 제목, 곡 난이도, 곡 이미지의 이름
    public string resultSongName;
    public string resultDifficulty;
    public string resultSongImageName;

    // 결과창에 보일 score, maxCombo 및 alive, early, late, dead 판정을 받은 노트의 개수
    public float resultScore;
    public int resultMaxCombo;
    public int resultAlive;
    public int resultEarly;
    public int resultLate;
    public int resultDead;


    private void Awake()
    {
        // 인스턴스가 이미 할당되었다면 ResultContainer 삭제 (여러개의 ResultContainer 생성을 막음 )
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        

    }

    void Update()
    {
        // PlayManager 오브젝트를 찾음 
        playManager = GameObject.Find("PlayManager");

        // ResultContainer의 변수에 데이터를 담아두고, ResultManager에서 꺼내서 사용
        if(playManager == null)
        {
            return;
        }

        resultSongName = playManager.GetComponent<playManager>().songName;
        resultDifficulty = playManager.GetComponent<playManager>().songDifficulty;
        resultSongImageName = playManager.GetComponent<playManager>().songArtImageName;
        resultScore = playManager.GetComponent<playManager>().score;
        resultMaxCombo = playManager.GetComponent<playManager>().maxCombo;
        resultAlive = playManager.GetComponent<playManager>().alive;
        resultEarly = playManager.GetComponent<playManager>().early;
        resultLate = playManager.GetComponent<playManager>().late;
        resultDead = playManager.GetComponent<playManager>().dead;

    }
}
