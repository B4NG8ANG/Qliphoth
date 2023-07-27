using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    // ResultContainer 스크립트를 참조하기 위한 변수
    private GameObject resultContainer;

    public GameObject resultSongArtImage;
    public GameObject resultSongDifficulty;
    public GameObject resultSongName;
    public GameObject resultSongScore;
    public GameObject resultComboNum;
    public GameObject resultAliveNum;
    public GameObject resultEarlyNum;
    public GameObject resultLateNum;
    public GameObject resultDeadNum;

   
    void Start()
    {
        // ResultContainer 오브젝트를 찾음 
        resultContainer = GameObject.Find("ResultContainer");

        // 곡 이미지 표시
        string songArtImageName = resultContainer.GetComponent<ResultContainer>().resultSongImageName;
        resultSongArtImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/SongArt/" + songArtImageName);

        // 곡 난이도 이미지 표시
        string resultDifficulty = resultContainer.GetComponent<ResultContainer>().resultDifficulty;
        resultSongDifficulty.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/" + resultDifficulty);

        // 곡 이름 표시
        string songName = resultContainer.GetComponent<ResultContainer>().resultSongName;
        resultSongName.GetComponent<Text>().text = songName;

        // 곡 점수 표시
        float resultScore = resultContainer.GetComponent<ResultContainer>().resultScore;
        resultSongScore.GetComponent<Text>().text = resultScore.ToString("0000000");

        // MaxCombo 표시
        int resultMaxCombo = resultContainer.GetComponent<ResultContainer>().resultMaxCombo;
        resultComboNum.GetComponent<Text>().text = resultMaxCombo.ToString();

        // Alive 판정 개수 표시
        int resultAlive = resultContainer.GetComponent<ResultContainer>().resultAlive;
        resultAliveNum.GetComponent<Text>().text = resultAlive.ToString();

        // Early 판정 개수 표시
        int resultEarly = resultContainer.GetComponent<ResultContainer>().resultEarly;
        resultEarlyNum.GetComponent<Text>().text = resultEarly.ToString();

        // Late 판정 개수 표시
        int resultLate = resultContainer.GetComponent<ResultContainer>().resultLate;
        resultLateNum.GetComponent<Text>().text = resultLate.ToString();

        // Dead 판정 개수 표시
        int resultDead = resultContainer.GetComponent<ResultContainer>().resultDead;
        resultDeadNum.GetComponent<Text>().text = resultDead.ToString();


    }

    
    void Update()
    {
        
    }
}
