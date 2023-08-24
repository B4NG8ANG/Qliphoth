using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class ResultManager : MonoBehaviour
{
    // ResultContainer 스크립트를 참조하기 위한 변수
    private GameObject resultContainer;

    // Result씬에서 보일 오브젝트
    public GameObject resultSongArtImage;
    public GameObject resultSongDifficulty;
    public GameObject resultSongName;
    public GameObject resultSongScore;
    public GameObject resultHighScore;
    public GameObject resultComboNum;
    public GameObject resultAliveNum;
    public GameObject resultEarlyNum;
    public GameObject resultLateNum;
    public GameObject resultDeadNum;
    public GameObject resultSongRank;
    public GameObject resultSongProgress;

   
    void Start()
    {
        // ResultContainer 오브젝트를 찾음 
        resultContainer = GameObject.Find("ResultContainer");

        // ResultContainer 넘어온 곡 id를 이용하여 곡 정보를 불러와 Song 클래스 타입의 song 변수에 저장
        string songID = resultContainer.GetComponent<ResultContainer>().resultSongID;
        Song song = songManager.Instance.getSongbyId(songID);

        // 곡 이미지 표시
        resultSongArtImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(song.songImageFileURL);

        // 곡 난이도 이미지 표시
        string resultDifficulty = resultContainer.GetComponent<ResultContainer>().resultDifficulty;
        resultSongDifficulty.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/" + resultDifficulty);

        // 곡 이름 표시
        string songName = song.songName;
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

        // Dead 판정 개수 표시
        int resultChartNoteCount = resultContainer.GetComponent<ResultContainer>().resultChartNoteCount;


        // All Alive, Full Combo, Clear 달성도 이미지 표시 및 곡 선택창으로 데이터 전송
        if(resultAlive == resultChartNoteCount)
        {
            resultSongProgress.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SongProgressImageAllAlive");
            PlayerPrefs.SetString("SongProgress" + songName + resultDifficulty, resultSongProgress.GetComponent<Image>().sprite.name);
        }
        else if(!(resultAlive == resultChartNoteCount) && resultMaxCombo == resultChartNoteCount)
        {
            resultSongProgress.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SongProgressImageFullCombo");

            if(!(PlayerPrefs.GetString("SongProgress" + songName + resultDifficulty) == "SongProgressImageAllAlive"))
            {
                PlayerPrefs.SetString("SongProgress" + songName + resultDifficulty, resultSongProgress.GetComponent<Image>().sprite.name);
            }
        }
        else if(!(resultAlive == resultChartNoteCount) && !(resultMaxCombo == resultChartNoteCount))
        {
            resultSongProgress.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SongProgressImageClear");

            if(!(PlayerPrefs.GetString("SongProgress" + songName + resultDifficulty) == "SongProgressImageAllAlive") && !(PlayerPrefs.GetString("SongProgress" + songName + resultDifficulty) == "SongProgressImageFullCombo"))
            {
                PlayerPrefs.SetString("SongProgress" + songName + resultDifficulty, resultSongProgress.GetComponent<Image>().sprite.name);
            }
        }


        // Highscore일때만 점수를 갱신 및 Highscore 오브젝트 활성화
        if(!PlayerPrefs.HasKey("SongScore" + songName + resultDifficulty) || resultScore > float.Parse(PlayerPrefs.GetString("SongScore" + songName + resultDifficulty)))
        {
            PlayerPrefs.SetString("SongScore" + songName + resultDifficulty, resultScore.ToString("0000000"));
            Debug.Log(float.Parse(PlayerPrefs.GetString("SongScore" + songName + resultDifficulty)));
            resultHighScore.SetActive(true);
        }
        
        
        // 점수별 랭크 설정
        string RankImgURL = "";
        if(resultScore >= 990000f)
        {
            RankImgURL = "Play/UI/RankImageSplus";
        }
        else if(990000f > resultScore && resultScore >= 980000f)
        {
            RankImgURL = "Play/UI/RankImage";
        }
        else if(980000f > resultScore && resultScore >= 950000f)
        {
            RankImgURL = "Play/UI/RankImageAplus";
        }
        else if(950000f > resultScore && resultScore >= 920000f)
        {
            RankImgURL = "Play/UI/RankImageA";
        }
        else if(920000f > resultScore && resultScore >= 890000f)
        {
            RankImgURL = "Play/UI/RankImageB";
        }
        else
        {
            RankImgURL = "Play/UI/RankImageC";
        }
        resultSongRank.GetComponent<Image>().sprite = Resources.Load<Sprite>(RankImgURL);

        Debug.Log("SongScore" + songName);
        Debug.Log(resultDifficulty);

        StartCoroutine(UnityWebRequestGET(song.id, resultScore));
    }

    // 곡 랭크 이미지랑 곡 달성도 이미지 저장 필요
    IEnumerator UnityWebRequestGET(string songName, float resultScore){
        string url = Constants.HOST+"score";
        WWWForm form = new WWWForm();

        form.AddField("song_id", songName);
        form.AddField("user_id", "dlwjddn");
        form.AddField("score", resultScore.ToString());

        UnityWebRequest www = UnityWebRequest.Post(url, form);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();

        if(www.error == null){
            Debug.Log(www.downloadHandler.text);
        }
        else{
            Debug.Log(www.error);
        }

        www.Dispose();
    }

    void Update()
    {
        
    }
}
