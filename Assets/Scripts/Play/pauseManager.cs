using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    // 일시정지 창
    public GameObject pausePanel;

    // 재시작 카운트다운 오브젝트
    public GameObject restartCountdownText;

    public void onPauseButtonClick()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void onRestartButtonClick()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Play");
        SceneChangeEffectManager.instance.FadeToScene("Play");
    }

    public void onContinueButtonClick()
    {
        pausePanel.SetActive(false);
        restartCountdownText.SetActive(true); 
    }

    public void onExitButtonClick()
    {
        pausePanel.SetActive(false);
        //SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
        SceneChangeEffectManager.instance.FadeToScene("Main");
        
    }

}
