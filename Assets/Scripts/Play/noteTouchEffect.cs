using UnityEngine;

public class noteTouchEffect : MonoBehaviour
{
    // 스케일 애니메이션의 지속 시간, 최대 스케일, 초기 스케일
    public float scaleDuration; 
    public float maxScale;
    private Vector3 initialScale;

    // 스크립트 시작 시각
    private float startTime;

    private void Start()
    {
        // 초기 스케일 저장
        initialScale = transform.localScale;

        // 시작 시간 저장
        startTime = Time.time;
    }

    private void Update()
    {
        // 경과 시간 계산
        float elapsedTime = Time.time - startTime;

        if (elapsedTime <= scaleDuration)
        {
            // 커지는 애니메이션
            float t = elapsedTime / scaleDuration; // 진행도 비율 계산
            float currentScale = Mathf.Lerp(initialScale.x, maxScale, t); // 보간하여 현재 스케일 계산
            transform.localScale = new Vector3(currentScale, currentScale, currentScale); // 스케일 설정
        }
        else
        {
            // 작아지고 사라지는 애니메이션
            float t = (elapsedTime - scaleDuration) / scaleDuration; // 진행도 비율 계산
            float currentScale = Mathf.Lerp(maxScale, 0f, t); // 보간하여 현재 스케일 계산
            transform.localScale = new Vector3(currentScale, currentScale, currentScale); // 스케일 설정

            if (currentScale <= 0f)
            {
                // 스케일이 0 이하가 되면 오브젝트 비활성화
                gameObject.SetActive(false);
            }
        }
    }
}
