using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetDifficulty()
    {
        // 이미지 하위의 텍스트를 이미지의 이름으로 (난이도) 변경
        transform.GetChild(0).GetComponent<Text>().text = transform.GetComponent<Image>().sprite.name;

        // 곡 선택창의 SongDifficulty 텍스트를 난이도로 변경
        GameObject SelectedSongDifficulty = GameObject.Find("SongDifficulty");
        SelectedSongDifficulty.GetComponent<Text>().text = transform.GetChild(0).GetComponent<Text>().text;

        GameObject songScore = GameObject.Find("SongScore");
        GameObject songName = GameObject.Find("SongName");
        GameObject normalSongScore = GameObject.Find("NormalSongScore");
        GameObject hardSongScore = GameObject.Find("HardSongScore");
        GameObject deathSongScore = GameObject.Find("DeathSongScore");

        if(GetComponent<Image>().sprite.name.Contains("Normal"))
        {
            if (PlayerPrefs.HasKey("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
            {
                songScore.GetComponent<Text>().text = PlayerPrefs.GetString("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name);
            }
            else
            {
                songScore.GetComponent<Text>().text = normalSongScore.GetComponent<Text>().text;
            }
        }
        else if(GetComponent<Image>().sprite.name.Contains("Hard"))
        {
            if (PlayerPrefs.HasKey("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
            {
                songScore.GetComponent<Text>().text = PlayerPrefs.GetString("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name);
            }
            else
            {
                songScore.GetComponent<Text>().text = hardSongScore.GetComponent<Text>().text;
            }
        }
        else if(GetComponent<Image>().sprite.name.Contains("Death"))
        {
            if (PlayerPrefs.HasKey("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name))
            {
                songScore.GetComponent<Text>().text = PlayerPrefs.GetString("SongScore" + songName.GetComponent<Text>().text + GetComponent<Image>().sprite.name);
            }
            else
            {
                songScore.GetComponent<Text>().text = deathSongScore.GetComponent<Text>().text;
            }
        }
        

        // 곡 선택 버튼에서 난이도 별 점수를 바로 곡 선택창의 점수 텍스트로 넘기지 말고,
        // 곡 선택창의 난이도 별 점수로 한번 보낸뒤 다시 거쳐서 오도록 변경 


    }
}
