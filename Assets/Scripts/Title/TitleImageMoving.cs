using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleImageMoving : MonoBehaviour
{
    // 실행중인 코루틴
    private Coroutine runningCoroutine;

    // 타이틀 이미지가 위로 올라가는 데 걸리는 시간
    public float floatDuration;

    // 타이틀 이미지의 원래 포지션
    private Vector3 initialPosition;

    // 시작 시간
    private float startTime;

    // 화면을 어둡다가 밝게 해주는 필터 이미지
    public GameObject backgroundFilterImage; 
    // Image 컴포넌트 참조
    private Image image;

    // 로고 이미지와 계정 버튼
    public GameObject logoImage;
    public GameObject titleAuthButton;

    // 카운트 변수
    private int count = 0;

    // 타이틀 효과 조작 버튼
    public GameObject titleControlButton; 

    private void Start()
    {
        // 타이틀 이미지 오브젝트의 초기 위치를 저장합니다.
        initialPosition = transform.position;
        startTime = Time.time; // 시작 시간을 기록합니다.
        image = backgroundFilterImage.GetComponent<Image>(); // Image 컴포넌트를 참조합니다.

        runningCoroutine = StartCoroutine(MoveAndBlink());
    }

    private IEnumerator MoveAndBlink()
    {
        float elapsedTime = 0f;
        while (elapsedTime < floatDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / floatDuration;

            // Lerp를 사용하여 타이틀 이미지 오브젝트를 움직입니다.
            //Vector3 targetPosition = initialPosition + Vector3.up * 15.0f;
            Vector3 targetPosition = new Vector3(initialPosition.x, 960, initialPosition.z);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, normalizedTime);

            // 필터 이미지의 Image 컴포넌트의 알파 값을 변경합니다.
            Color imageColor = image.color;
            imageColor.a = Mathf.Lerp(1.0f, 0.0f, normalizedTime);
            image.color = imageColor;

            yield return null;
        }
        // 움직임이 완료된 후에 코루틴을 호출하여 효과를 적용합니다.
        StartCoroutine(BlinkAndFadeOut());
    }
    
    private IEnumerator BlinkAndFadeOut()
    {
        // 움직임이 완료될 때까지 대기합니다.
        //yield return new WaitForSeconds(floatDuration);

        // 필터 이미지를 하얀색으로 변경합니다.
        Color imageColor = Color.white;
        image.color = imageColor;

        // 0.5초 대기 후에 투명도를 0으로 만듭니다.
        yield return new WaitForSeconds(0.4f);

        // 필터 이미지의 투명도를 0으로 설정합니다.
        imageColor.a = 0.0f;
        image.color = imageColor;

        // 로고 이미지와 계정 버튼을 활성화 합니다.
        logoImage.SetActive(true);
        titleAuthButton.SetActive(true);

    }

    // 실행 중인 코루틴을 중지하는 함수
    private void StopRunningCoroutine()
    {
        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
            runningCoroutine = null;
        }
    }

    // 타이틀 화면 클릭
    public void onTitleClick()
    {
        if(logoImage.activeSelf && titleAuthButton.activeSelf)
        {
            SceneChangeEffectManager.instance.FadeToScene("Main");
        }

        else
        {
            StopRunningCoroutine();
            StartCoroutine(BlinkAndFadeOut());
        }
    }

    // private void Update()
    // {
    //     // 현재 시간과 시작 시간의 차이를 계산하여 오브젝트를 움직입니다.
    //     float elapsedTime = Time.time - startTime;
    //     float normalizedTime = Mathf.Clamp01(elapsedTime / floatDuration); // 정규화된 시간 (0에서 1 사이의 값)

    //     // Lerp를 사용하여 오브젝트를 움직입니다.
    //     Vector3 targetPosition = initialPosition + Vector3.up * 10.0f; // 움직일 최종 위치 (위로 10 유닛 이동)
    //     transform.position = Vector3.Lerp(initialPosition, targetPosition, normalizedTime);

    //     // Image 컴포넌트의 알파 값을 변경합니다.
    //     Color imageColor = image.color;
    //     imageColor.a = Mathf.Lerp(1.0f, 0.0f, normalizedTime); // 1.0f에서 0.0f로 알파 값을 변경
    //     image.color = imageColor;

    //     // 만약 움직임이 완료되면 움직임을 중지할 수 있습니다.
    //     if (normalizedTime >= 1.0f && count == 0)
    //     {
    //         // 움직임을 중지하거나 필요한 다른 동작을 수행합니다.
    //         StartCoroutine(BlinkAndFadeOut());
    //         logoImage.SetActive(true);
    //         titleAuthButton.SetActive(true);
    //         count += 1;
    //     }
    // }


}

