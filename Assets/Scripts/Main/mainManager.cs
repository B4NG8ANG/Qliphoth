using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainManager : MonoBehaviour
{
    // mainManager 객체의 인스턴스 생성
    public static mainManager Instance;

    // 곡 선택창
    GameObject songSelectPanel;

    // Play 씬으로 넘겨줘야 할 정보들을 저장
    GameObject songDifficultyContainer; // 곡 난이도를 담는 컨테이너 오브젝트
    GameObject songIDContainer; // 곡 ID를 담는 컨테이너 오브젝트

    // Play 씬으로 넘겨줘야 할 정보를 저장하는 변수들
    public string songDifficulty;
    public string songID;
    
    private void Awake()
    {
        // 인스턴스가 이미 할당되었다면 mainManager 삭제 (여러개의 mainManager 생성을 막음 )
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
        // 곡 정보를 매 프레임마다 갱신
        songSelectPanel = GameObject.Find("SongSelectPanel"); // 곡 선택창 패널
        songDifficultyContainer = GameObject.Find("SongDifficultyContainer"); // 곡 난이도를 가지고 있는 오브젝트
        songIDContainer = GameObject.Find("SongIDContainer"); // 곡 ID를 가지고 있는 오브젝트

        // 변수에 데이터를 담아두고, 다른 씬에서 mainManager에 접근하여 사용
        if(songSelectPanel != null)
        {
            if(songSelectPanel.activeSelf)
            {
                songDifficulty = songDifficultyContainer.GetComponent<Text>().text;
                songID = songIDContainer.GetComponent<Text>().text;
            }
        }
        
    }
}
