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

    // 결과창에 보일 곡의 ID, 곡 난이도
    public string resultDifficulty;
    public string resultSongID;

    // 결과창에 보일 score, maxCombo 및 alive, early, late, dead 판정을 받은 노트의 개수
    public float resultScore;
    public int resultMaxCombo;
    public int resultAlive;
    public int resultEarly;
    public int resultLate;
    public int resultDead;

    // 결과창에서 사용할 전체 노트의 개수
    public int resultChartNoteCount;

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

        // Play씬 밖에서는 실행하지 않음
        if(playManager == null)
        {
            return;
        }

        // ResultContainer의 변수에 데이터를 담아두고, ResultManager에서 ResultContainer에 접근하여 사용
        resultSongID = playManager.GetComponent<playManager>().songID;
        resultDifficulty = playManager.GetComponent<playManager>().songDifficulty;
        resultScore = playManager.GetComponent<playManager>().score;
        resultMaxCombo = playManager.GetComponent<playManager>().maxCombo;
        resultAlive = playManager.GetComponent<playManager>().alive;
        resultEarly = playManager.GetComponent<playManager>().early;
        resultLate = playManager.GetComponent<playManager>().late;
        resultDead = playManager.GetComponent<playManager>().dead;
        resultChartNoteCount = playManager.GetComponent<playManager>().chartNoteCount;
    }
}
