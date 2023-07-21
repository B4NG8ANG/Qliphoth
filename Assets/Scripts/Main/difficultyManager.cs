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
        GameObject SelectedSongDifficulty = GameObject.Find("SelectedSongDifficulty");
        SelectedSongDifficulty.GetComponent<Text>().text = transform.GetChild(0).GetComponent<Text>().text;
    }
}
