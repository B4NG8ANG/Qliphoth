using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound1;

    public void onPlayButtonClick()
    {
        //SceneManager.LoadScene("Play");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound1;
        audioSource.Play();
        SceneChangeEffectManager.instance.FadeToScene("Play");
    }

    public void onSettingButtonClick()
    {
        SceneChangeEffectManager.instance.FadeToScene("Setting");
    }

    /*
    public void onTitleClick()
    {
        //SceneManager.LoadScene("Main");
        SceneChangeEffectManager.instance.FadeToScene("Main");
    }
    */
}
