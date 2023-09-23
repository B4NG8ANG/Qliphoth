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
        PlayerPrefs.DeleteKey("SongProgressCytus IINormal1");
        PlayerPrefs.DeleteKey("SongProgressCytus IIHard3");
        PlayerPrefs.DeleteKey("SongProgressCytus IIDeath5");

        PlayerPrefs.DeleteKey("SongScoreFracture RayNormal4");
        PlayerPrefs.DeleteKey("SongScoreFracture RayHard6");
        PlayerPrefs.DeleteKey("SongScoreFracture RayDeath10");
        PlayerPrefs.DeleteKey("SongProgressFracture RayNormal4");
        PlayerPrefs.DeleteKey("SongProgressFracture RayHard6");
        PlayerPrefs.DeleteKey("SongProgressFracture RayDeath10");

        PlayerPrefs.DeleteKey("SongScoreConversations with strangersNormal1");
        PlayerPrefs.DeleteKey("SongScoreConversations with strangersHard3");
        PlayerPrefs.DeleteKey("SongScoreConversations with strangersDeath5");
        PlayerPrefs.DeleteKey("SongProgressConversations with strangersNormal1");
        PlayerPrefs.DeleteKey("SongProgressConversations with strangersHard3");
        PlayerPrefs.DeleteKey("SongProgressConversations with strangersDeath5");

        PlayerPrefs.DeleteKey("VolumeAmount");
        PlayerPrefs.DeleteKey("BrightAmount");

    }
}
