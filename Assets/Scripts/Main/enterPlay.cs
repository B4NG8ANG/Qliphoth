using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterPlay : MonoBehaviour
{

    public void onPlayButtonClick()
    {
        //SceneManager.LoadScene("Play");
        SceneChangeEffectManager.instance.FadeToScene("Play");
    }
}
