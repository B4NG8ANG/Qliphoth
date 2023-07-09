using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class songSelectManager : MonoBehaviour
{
    public GameObject songSelectPanel; // 곡 선택창
    public GameObject songArtImage; // 곡 앨범 아트 이미지
    public GameObject birthDifficultyImage; // birth 난이도 버튼 이미지
    public GameObject lifeDifficultyImage; // life 난이도 버튼 이미지
    public GameObject deathDifficultyImage; // death 난이도 버튼 이미지
    public GameObject songName; // 곡 이름 텍스트
    public GameObject songComposerName; // 곡 작곡가 이름 텍스트
    public GameObject songScore; // 곡에서 받은 점수
    public GameObject songProgress; // 곡에서 달성한 달성도 (Perfect Alive, Full Alive, Clear, Fail)
    public GameObject songRank; // 곡에서 달성한 랭크 (S+, S, A+, A, B, C)

    public GameObject selectedSongArtImage; // 선택된 곡 앨범 아트 이미지
    public GameObject selectedSongName; // 선택된 곡 이름 텍스트
    public GameObject selectedSongComposer; // 선택된 곡 이름 텍스트


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSongSelectButtonClick()
    {
        songSelectPanel.SetActive(true);
        songArtImage.GetComponent<Image>().sprite = selectedSongArtImage.GetComponent<Image>().sprite;
        songName.GetComponent<Text>().text = selectedSongName.GetComponent<Text>().text;
        songComposerName.GetComponent<Text>().text = selectedSongComposer.GetComponent<Text>().text;
    }

}
