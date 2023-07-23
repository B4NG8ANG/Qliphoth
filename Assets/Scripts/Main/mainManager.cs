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
    GameObject songArtImageObject; // 곡 앨범 아트 이미지
    GameObject songNameObject; // 곡 이름 텍스트
    GameObject songComposerNameObject; // 곡 작곡가 이름 텍스트
    GameObject difficultyImageObject; // 난이도 버튼 이미지
    public AudioSource song; // 플레이 할 곡 음원

    // Play 씬으로 넘겨줘야 할 정보 변수들
    public string songName;
    public string songArtImageName;
    public string songComposerName;
    public string songDifficulty;
    
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
        songNameObject = GameObject.Find("SelectedSongName"); // 곡 이름 텍스트 오브젝트
        songArtImageObject = GameObject.Find("SelectedSongArtImage"); // 곡 이미지 이미지 오브젝트
        songComposerNameObject = GameObject.Find("SelectedSongComposerName"); // 곡 작곡가 텍스트 오브젝트
        difficultyImageObject = GameObject.Find("SelectedSongDifficulty"); // 곡 난이도 텍스트 오브젝트

        // 변수에 데이터를 담아두고, 다른 씬에서 꺼내서 사용
        if(songSelectPanel != null)
        {
            if(songSelectPanel.activeSelf)
            {
                songName = songNameObject.GetComponent<Text>().text;
                songArtImageName = songArtImageObject.GetComponent<Image>().sprite.name;
                songComposerName = songComposerNameObject.GetComponent<Text>().text;
                songDifficulty = difficultyImageObject.GetComponent<Text>().text;
            }
        }
        
        
    }
}
