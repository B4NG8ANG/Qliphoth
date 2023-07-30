using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDataDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDelete()
    {
        PlayerPrefs.DeleteKey("SongScoreCytus IINormal1");
        PlayerPrefs.DeleteKey("SongScoreCytus IIHard3");
        PlayerPrefs.DeleteKey("SongScoreCytus IIDeath5");

    }
}
