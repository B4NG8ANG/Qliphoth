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
        transform.GetChild(0).GetComponent<Text>().text = transform.GetComponent<Image>().sprite.name;
        GameObject SelectedSongDifficulty = GameObject.Find("SongDifficulty");
        SelectedSongDifficulty.GetComponent<Text>().text = transform.GetChild(0).GetComponent<Text>().text;
    }
}
