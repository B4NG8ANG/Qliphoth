using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class songSelectManager : MonoBehaviour
{
    // 곡 선택창에 보여질 정보
    public GameObject songSelectButtonObject; // 곡 선택 버튼
    public GameObject songSelectPanel; // 곡 선택창
    public GameObject songArtImage; // 곡 앨범 아트 이미지
    public GameObject normalDifficultyImage; // normal 난이도 버튼 이미지
    public GameObject hardDifficultyImage; // hard 난이도 버튼 이미지
    public GameObject deathDifficultyImage; // death 난이도 버튼 이미지
    public GameObject songName; // 곡 이름 텍스트
    public GameObject songComposerName; // 곡 작곡가 이름 텍스트
    public GameObject songScore; // 곡에서 받은 점수
    public GameObject songProgress; // 곡에서 달성한 달성도 (Perfect Alive, Full Alive, Clear, Fail)
    public GameObject songRank; // 곡에서 달성한 랭크 (S+, S, A+, A, B, C)

    // 곡 선택 버튼이 가지고 있는 정보
    public GameObject selectedSongArtImage; // 선택된 곡 앨범 아트 이미지
    public GameObject selectedSongName; // 선택된 곡 이름 텍스트
    public GameObject selectedSongComposer; // 선택된 곡 이름 텍스트
    public GameObject selectedNormalDifficultyImage; // normal 난이도 버튼 이미지
    public GameObject selectedHardDifficultyImage; // hard 난이도 버튼 이미지
    public GameObject selectedDeathDifficultyImage; // death 난이도 버튼 이미지

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 곡 선택 아이콘 클릭시 호출
    public void onSongSelectButtonClick()
    {
        // 곡 선택 아이콘 클릭시 곡 이미지가 보이지 않는 상태였다면 곡 이미지를 보여줌
        if(!selectedSongArtImage.activeSelf)
        {
            selectedSongArtImage.SetActive(true);
            songSelectButtonObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SelectedSongSelectButtonImage");
            return;
        }

        // 곡 선택 패널 활성화
        songSelectPanel.SetActive(true);

        // 곡 선택창의 정보들 설정
        songArtImage.GetComponent<Image>().sprite = selectedSongArtImage.GetComponent<Image>().sprite; // 곡 이미지
        songName.GetComponent<Text>().text = selectedSongName.GetComponent<Text>().text; // 곡 이름
        songComposerName.GetComponent<Text>().text = selectedSongComposer.GetComponent<Text>().text; // 곡 작곡가 이름
        normalDifficultyImage.GetComponent<Image>().sprite = selectedNormalDifficultyImage.GetComponent<Image>().sprite; // 곡 이미지
        hardDifficultyImage.GetComponent<Image>().sprite = selectedHardDifficultyImage.GetComponent<Image>().sprite; // 곡 이미지
        deathDifficultyImage.GetComponent<Image>().sprite = selectedDeathDifficultyImage.GetComponent<Image>().sprite; // 곡 이미지

        // 곡에서 받은 점수, 달성도, 랭크를 받아와서 여기서 보여줘야함
    }

    // 활성화 된 곡 이미지 버튼 클릭시 호출 
    public void onSongImageButtonClick()
    {
        selectedSongArtImage.SetActive(false);
        songSelectButtonObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SongSelectButtonImage");
    }

}
