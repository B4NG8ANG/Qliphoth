using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{

    public void onPlayButtonClick()
    {
        //SceneManager.LoadScene("Play");
        SceneChangeEffectManager.instance.FadeToScene("Play");
    }

    public void onSettingButtonClick()
    {
        SceneChangeEffectManager.instance.FadeToScene("Setting");
    }
}
