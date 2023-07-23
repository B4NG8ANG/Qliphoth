using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeEffectManager : MonoBehaviour
{
    public static SceneChangeEffectManager instance;

    public GameObject SceneChangeEffectCanvas;
    public float fadeDuration = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            
        else if (instance != this)
        {
            Destroy(gameObject);
        }
            
        DontDestroyOnLoad(gameObject);
    }


    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }


    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        SceneChangeEffectCanvas.SetActive(true);
        CanvasGroup canvasGroup = SceneChangeEffectCanvas.GetComponent<CanvasGroup>();
        float timeStarted = Time.time;
        float startAlpha = 0f;
        float targetAlpha = 1f;

        while (Time.time < timeStarted + fadeDuration)
        {
            float percentage = (Time.time - timeStarted) / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, percentage);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        SceneManager.LoadScene(sceneName);
        yield return null;

        // 씬이 다시 밝아지는 코드
        // timeStarted = Time.time;
        // startAlpha = 1f;
        // targetAlpha = 0f;

        // while (Time.time < timeStarted + fadeDuration)
        // {
        //     float percentage = (Time.time - timeStarted) / fadeDuration;
        //     canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, percentage);
        //     yield return null;
        // }

        // canvasGroup.alpha = targetAlpha;

        SceneChangeEffectCanvas.SetActive(false);
    }
}
