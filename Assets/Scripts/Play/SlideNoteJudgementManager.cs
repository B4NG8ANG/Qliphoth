using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideNoteJudgementManager : MonoBehaviour, IPointerExitHandler
{
    // playManager 스크립트를 참조하기 위한 변수
    private playManager playManagerScript;

    // 판정선 시작, 목표 크기, 감소 애니메이션 지속 시간
    public Vector3 judgementLineStartScale;
    public Vector3 judgementLineTargetScale;
    public float judgementLineComingDuration;

    // 스크립트 시작 시각
    private float startTime;

    // 스크립트 시작 후 경과 시간
    private float elapsedTime;

    // 판정선 transform
    private Transform judgementLineTransform;

    // 판정선, 노트
    public GameObject judgementLine; 
    public GameObject note;

    // 노트가 삭제되기까지 걸리는 시간 (노트 오브젝트 지속 시간)
    public float noteDeletingTime;

    // 터치를 했는지 감지하는 변수
    public bool touched = false;
    
    // 이펙트 이미지
    public GameObject noteEffect;

    // 노트 터치 판정 이미지
    public GameObject judgementImageAlive;
    public GameObject judgementImageEarly;
    public GameObject judgementImageLate;
    public GameObject judgementImageDead;


    void Start()
    {
        // 판정선 transform 저장
        judgementLineTransform = judgementLine.transform;

        // 시작 시간 저장
        startTime = Time.time;

        // playManager라는 컴포넌트를 가진 오브젝트중 제일 처음 것을 찾고, 그 컴포넌트를 참조 
        playManagerScript = FindObjectOfType<playManager>();

        noteEffect.SetActive(false);
        judgementImageAlive.SetActive(false);
        judgementImageEarly.SetActive(false);
        judgementImageLate.SetActive(false);
        judgementImageDead.SetActive(false);

    }

    void Update()
    {
        // 경과 시간 계산
        elapsedTime = Time.time - startTime;

        // 시간 비율 (0 ~ 1) 
        float t = Mathf.Clamp01(elapsedTime / judgementLineComingDuration); 

        // 판정선을 시작 크기에서 목표 크기로 보간
        Vector3 currentScale = Vector3.Lerp(judgementLineStartScale, judgementLineTargetScale, t);

        // 판정선 크기를 적용
        judgementLineTransform.localScale = currentScale;

        /*
        // 애니메이션이 종료되면 스크립트 비활성화
        if (t >= 1f)
        {
            enabled = false;
        }
        */

        // 터치 되지 않은채로 노트 지속시간이 경과되면 Dead 판정 후 삭제
        if(!touched && elapsedTime > noteDeletingTime)
        {
            touched = true;
            playManagerScript.AddCombo(false);
            playManagerScript.CountJudgement("dead");
            Invoke("RemoveNote", 0.3f);
            judgementImageDead.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 노트 지속시간이 경과되면 터치 이벤트를 무시
        if (elapsedTime >= noteDeletingTime)
        {
            return;
        }

        // 이미 터치 되어 처리가 된 슬라이드 노트는 터치 이벤트를 무시하여 중복 처리 금지
        if (touched)
        {
            return;
        }

        touched = true;
        float touchElapsedTime = Time.time - startTime;

        if(touchElapsedTime < 0.4f)
        {
            playManagerScript.AddCombo(true);
            playManagerScript.CountJudgement("early");
            playManagerScript.AddScore(false);
            Invoke("RemoveNote", 0.3f);
            noteEffect.SetActive(true);
            judgementImageEarly.SetActive(true);
        }
        else if(touchElapsedTime >= 0.4f && touchElapsedTime <= 0.6f)
        {
            playManagerScript.AddCombo(true);
            playManagerScript.CountJudgement("alive");
            playManagerScript.AddScore(true);
            Invoke("RemoveNote", 0.3f);
            noteEffect.SetActive(true);
            judgementImageAlive.SetActive(true);
        }
        else if(touchElapsedTime > 0.6f ) // && touchElapsedTime <= 0.8f)
        {
            playManagerScript.AddCombo(true);
            playManagerScript.CountJudgement("late");
            playManagerScript.AddScore(false);
            Invoke("RemoveNote", 0.3f);
            noteEffect.SetActive(true);
            judgementImageLate.SetActive(true);
        }
        // else if(touchElapsedTime > 0.8f)
        // {
        //     playManagerScript.AddCombo(false);
        //     gameObject.SetActive(false);
        // }
        
    }

    private void RemoveNote()
    {
        note.SetActive(false);
    }

}
