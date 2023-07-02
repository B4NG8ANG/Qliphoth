using UnityEngine;

public class SquareScaler : MonoBehaviour
{
    public Vector3 startScale = new Vector3(250f, 250f, 1f); // 시작 크기
    public Vector3 targetScale = new Vector3(175f, 175f, 1f); // 목표 크기
    public float duration = 1f; // 애니메이션 시간

    private float startTime;
    private Transform squareTransform;

    private void Start()
    {
        squareTransform = transform;
        startTime = Time.time; // 시작 시간 저장
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime; // 경과 시간 계산
        float t = Mathf.Clamp01(elapsedTime / duration); // 시간 비율 (0 ~ 1)

        // 시작 크기에서 목표 크기로 보간
        Vector3 currentScale = Vector3.Lerp(startScale, targetScale, t);

        // 크기를 적용
        squareTransform.localScale = currentScale;

        // 애니메이션이 종료되면 스크립트 비활성화
        if (t >= 1f)
        {
            enabled = false;
        }
    }
}