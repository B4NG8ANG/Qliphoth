using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class songSelectManager : MonoBehaviour
{
    // 메인씬 상단에 보여지는 메뉴바
    public GameObject menu;

    // 곡 선택 버튼이 가지고 있는 정보
    public GameObject selectedSongID; // 선택된 곡의 ID

    // 곡 선택창에 보여지는 정보
    public GameObject songSelectButtonObject; // 곡 선택 버튼
    public GameObject songSelectPanel; // 곡 선택창
    public GameObject songArtImage; // 곡 앨범 아트 이미지
    public GameObject normalDifficultyImage; // normal 난이도 버튼 이미지
    public GameObject hardDifficultyImage; // hard 난이도 버튼 이미지
    public GameObject deathDifficultyImage; // death 난이도 버튼 이미지
    public GameObject clickedNormalDifficultyImage; // normal 난이도가 선택되면 보일 버튼 이미지
    public GameObject clickedHardDifficultyImage; // hard 난이도가 선택되면 보일 버튼 이미지
    public GameObject clickedDeathDifficultyImage; // death 난이도가 선택되면 보일 버튼 이미지
    public GameObject songName; // 곡 이름 텍스트
    public GameObject songComposerName; // 곡 작곡가 이름 텍스트
    public GameObject songScore; // 곡에서 받은 점수
    public GameObject songProgress; // 곡에서 달성한 달성도 (Perfect Alive, Full Alive, Clear, Fail)
    public GameObject songRank; // 곡에서 달성한 랭크 (S+, S, A+, A, B, C)
    public GameObject songIDContainer; // 곡 ID 텍스트

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 곡 선택 아이콘 클릭시 호출
    public void onSongSelectButtonClick()
    {
        // 상단 메뉴바 비활성화
        menu.SetActive(false);

        // 곡 선택창 활성화
        songSelectPanel.SetActive(true);

        // songManager에서 아이콘이 가지고 있던 곡 id를 이용하여 곡 정보를 불러옴
        Song song = songManager.Instance.getSongbyId(selectedSongID.GetComponent<Text>().text);
        songIDContainer.GetComponent<Text>().text = selectedSongID.GetComponent<Text>().text;

        // 불러와진 곡 정보를 이용하여 곡 선택창의 정보들 설정
        if(song != null)
        {
            songArtImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(song.songImageFileURL); // 곡 이미지
            songName.GetComponent<Text>().text = song.songName; // 곡 이름
            songComposerName.GetComponent<Text>().text = song.songComposer; // 곡 작곡가 이름

            normalDifficultyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(song.songNormalDifficultyURL); // 곡 Normal 난이도 이미지
            hardDifficultyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(song.songHardDifficultyURL); // 곡 Hard 난이도 이미지
            deathDifficultyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(song.songDeathDifficultyURL); // 곡  Death 난이도 이미지

            clickedNormalDifficultyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SelectedNormal" + song.songNormalDifficulty); // 곡 Normal 난이도 선택된 이미지
            clickedHardDifficultyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SelectedHard" + song.songHardDifficulty); // 곡 Hard 난이도 선택된 이미지
            clickedDeathDifficultyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SelectedDeath" + song.songDeathDifficulty); // 곡 Death 난이도 선택된 이미지
        }

        // 곡 선택창 활성화 시 노멀 난이도가 선택되도록 고정
        normalDifficultyImage.GetComponent<difficultyManager>().SetDifficulty();

    }

}
