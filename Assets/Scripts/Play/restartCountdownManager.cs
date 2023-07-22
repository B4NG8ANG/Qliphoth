using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restartCountdownManager : MonoBehaviour
{
    public GameObject restartCountdownText;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        // 3, 2, 1, Go 텍스트를 각각 1초씩 걸쳐서 표시합니다.
        restartCountdownText.GetComponent<Text>().text = "3";
        yield return new WaitForSecondsRealtime(1f);

        restartCountdownText.GetComponent<Text>().text = "2";
        yield return new WaitForSecondsRealtime(1f);

        restartCountdownText.GetComponent<Text>().text = "1";
        yield return new WaitForSecondsRealtime(1f);

        restartCountdownText.GetComponent<Text>().text = "Go!";
        yield return new WaitForSecondsRealtime(1f);

        // 타이머가 끝나면 게임 재개
        Time.timeScale = 1f;
        restartCountdownText.SetActive(false);
    }
}
