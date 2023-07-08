using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideNoteJudgementManager : MonoBehaviour, IDragHandler
{
    public Vector3 judgementLineStartScale; // 판정선 시작 크기
    public Vector3 judgementLineTargetScale; // 판정선 목표 크기
    public float judgementLineComingDuration; // 판정선 감소 애니메이션 시간
    private float startTime; // 스크립트 시작 시간
    private Transform judgementLineTransform; // 판정선 transform

    public GameObject judgementLine;  // 판정선 오브젝트
    public GameObject note; // 노트 오브젝트
    GameObject judgementTextTest; // 판정 텍스트 오브젝트
    public float noteDeletingTime; // 노트 삭제 시간

    
    void Start()
    {
        Invoke("RemoveNote", noteDeletingTime);

        // 판정선 transform 저장
        judgementLineTransform = judgementLine.transform;

        
        judgementTextTest = GameObject.Find("JudgementTextTest");

        // 시작 시간 저장
        startTime = Time.time;

    }

    void Update()
    {
        // 경과 시간 계산
        float elapsedTime = Time.time - startTime;
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
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        float touchElapsedTime = Time.time - startTime;
        Debug.Log(touchElapsedTime);

        if(touchElapsedTime < 0.45f)
        {
            judgementTextTest.GetComponent<Text>().text = "Early Choice";
            Destroy(note);
        }
        else if(touchElapsedTime >= 0.45f && touchElapsedTime <= 0.55f)
        {
            judgementTextTest.GetComponent<Text>().text = "Alive";
            Destroy(note);
        }
        else if(touchElapsedTime > 0.55f && touchElapsedTime <= 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Late Choice";
            Destroy(note);
        }
        else if(touchElapsedTime > 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            Destroy(note);
        }
        
    }

    private void RemoveNote()
    {
        judgementTextTest.GetComponent<Text>().text = "Dead";
        Destroy(note); // 현재 오브젝트를 삭제합니다.
    }

}
