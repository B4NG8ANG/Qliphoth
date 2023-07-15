using UnityEngine;

public class longNoteTouchEffect : MonoBehaviour
{
    public float scaleDuration; // 스케일 애니메이션의 지속 시간
    public float maxScale; // 최대 스케일
    public float rotationSpeed; // 회전 속도

    public GameObject longNote;

    private Vector3 initialScale; // 초기 스케일
    private float timer; // 타이머

    private void Start()
    {
        initialScale = transform.localScale; // 초기 스케일 저장
        scaleDuration = longNote.GetComponent<LongNoteJudgementManager>().noteDeletingTime;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= scaleDuration)
        {
            // 커지는 애니메이션
            float t = timer / scaleDuration; // 진행도 비율 계산
            float currentScale = Mathf.Lerp(initialScale.x, maxScale, t); // 보간하여 현재 스케일 계산
            transform.localScale = new Vector3(currentScale, currentScale, currentScale); // 스케일 설정

            // 시계방향으로 회전
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // 작아지고 사라지는 애니메이션
            float t = (timer - scaleDuration) / scaleDuration; // 진행도 비율 계산
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
