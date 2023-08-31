using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyManager : MonoBehaviour
{
    public GameObject clickedNormalDifficultyImage;
    public GameObject clickedHardDifficultyImage;
    public GameObject clickedDeathDifficultyImage;
    public GameObject rankingManager;
    public GameObject selectedSongID;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetDifficulty()
    {
        // 곡 선택창의 SongDifficultyContainer 텍스트를 클릭된 난이도로 변경
        GameObject SelectedSongDifficulty = GameObject.Find("SongDifficultyContainer");
        SelectedSongDifficulty.GetComponent<Text>().text = transform.GetComponent<Image>().sprite.name;

        GameObject songScore = GameObject.Find("SongScore");
        GameObject songName = GameObject.Find("SongName");
        GameObject songRank = GameObject.Find("SongRank");
        GameObject songProgress = GameObject.Find("SongProgress");
        GameObject normalDifficultyImage = GameObject.Find("NormalDifficultyImage");
        GameObject hardDifficultyImage = GameObject.Find("HardDifficultyImage");
        GameObject deathDifficultyImage = GameObject.Find("DeathDifficultyImage");
        // GameObject clickedNormalDifficultyImage = GameObject.Find("ClickedNormalDifficultyImage");
        // GameObject clickedHardDifficultyImage = GameObject.Find("ClickedHardDifficultyImage");
        // GameObject clickedDeathDifficultyImage = GameObject.Find("ClickedDeathDifficultyImage");
        // GameObject normalSongScore = GameObject.Find("NormalSongScore");
        // GameObject hardSongScore = GameObject.Find("HardSongScore");
        // GameObject deathSongScore = GameObject.Find("DeathSongScore");
        

        if(GetComponent<Image>().sprite.name.Contains("Normal"))
        {
            //곡 점수 텍스트, 달성도 이미지 설정
            SetScoreAndProgress(songName, songScore, songProgress);
            
            // 난이도 버튼 선택시 선택된 이미지로 변경
            clickedNormalDifficultyImage.SetActive(true);
            clickedHardDifficultyImage.SetActive(false);
            clickedDeathDifficultyImage.SetActive(false);

            // 곡 선택창 활성화 시 랭킹 매니저의 코루틴이 실행되도록 설정
            rankingManager.GetComponent<RankingManager>().StartRank(selectedSongID.GetComponent<Text>().text, "Normal");
        }
        else if(GetComponent<Image>().sprite.name.Contains("Hard"))
        {
            //곡 점수 텍스트, 달성도 이미지 설정
            SetScoreAndProgress(songName, songScore, songProgress);

            // 난이도 버튼 선택시 선택된 이미지로 변경
            clickedNormalDifficultyImage.SetActive(false);
            clickedHardDifficultyImage.SetActive(true);
            clickedDeathDifficultyImage.SetActive(false);

            // 곡 선택창 활성화 시 랭킹 매니저의 코루틴이 실행되도록 설정
            rankingManager.GetComponent<RankingManager>().StartRank(selectedSongID.GetComponent<Text>().text, "Hard");
        }
        else if(GetComponent<Image>().sprite.name.Contains("Death"))
        {
            //곡 점수 텍스트, 달성도 이미지 설정
            SetScoreAndProgress(songName, songScore, songProgress);

            // 난이도 버튼 선택시 선택된 이미지로 변경
            clickedNormalDifficultyImage.SetActive(false);
            clickedHardDifficultyImage.SetActive(false);
            clickedDeathDifficultyImage.SetActive(true);

            // 곡 선택창 활성화 시 랭킹 매니저의 코루틴이 실행되도록 설정
            rankingManager.GetComponent<RankingManager>().StartRank(selectedSongID.GetComponent<Text>().text, "Death");
        }
        
        // 점수별 랭크 설정
        float score = float.Parse(songScore.GetComponent<Text>().text);
        
        if(PlayerPrefs.HasKey("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
        {
            if(score >= 990000f)
            {
                songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageSplus");
            }
            else if(990000f > score && score >= 980000f)
            {
                songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImage");
            }
            else if(980000f > score && score >= 950000f)
            {
                songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageAplus");
            }
            else if(950000f > score && score >= 920000f)
            {
                songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageA");
            }
            else if(920000f > score && score >= 890000f)
            {
                songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageB");
            }
            else if(890000f > score)
            {
                songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageC");
            }
        }
        else if(!PlayerPrefs.HasKey("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
        {
            songRank.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageNone");
        }

        // 곡 선택 버튼에서 난이도 별 점수를 바로 곡 선택창의 점수 텍스트로 넘기지 말고,
        // 곡 선택창의 난이도 별 점수로 한번 보낸뒤 다시 거쳐서 오도록 변경

    }

    public void SetScoreAndProgress(GameObject songName, GameObject songScore, GameObject songProgress)
    {
        // 곡 점수 텍스트 설정
        // PlayerPrefs 키가 없을 경우 한번도 플레이 한적이 없는 곡으로 간주
        if (PlayerPrefs.HasKey("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
        {
            songScore.GetComponent<Text>().text = PlayerPrefs.GetString("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name);
        }
        else
        {
            //songScore.GetComponent<Text>().text = deathSongScore.GetComponent<Text>().text;
            songScore.GetComponent<Text>().text = "0000000";
        }

        // 곡 달성도 이미지 설정
        if (PlayerPrefs.HasKey("SongProgress" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
        {
            songProgress.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/" + PlayerPrefs.GetString("SongProgress" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name));
        }
        else
        {
            songProgress.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/Transparent");
        }
    }

}
