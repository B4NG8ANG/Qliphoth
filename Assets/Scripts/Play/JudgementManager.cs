using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JudgementManager : MonoBehaviour, IPointerDownHandler
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
        Invoke("RemoveObject", noteDeletingTime);

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

        // 시작 크기에서 목표 크기로 보간
        Vector3 currentScale = Vector3.Lerp(judgementLineStartScale, judgementLineTargetScale, t);

        // 크기를 적용
        judgementLineTransform.localScale = currentScale;

        /*
        // 애니메이션이 종료되면 스크립트 비활성화
        if (t >= 1f)
        {
            enabled = false;
        }
        */
        
    }

    // 노트 터치
    public void OnPointerDown(PointerEventData eventData)
    {
        float touchElapsedTime = Time.time - startTime;
        Debug.Log(touchElapsedTime);

        if(touchElapsedTime < 0.46f)
        {
            judgementTextTest.GetComponent<Text>().text = "Early Choice";
            Destroy(note);
        }
        else if(touchElapsedTime >= 0.46f && touchElapsedTime <= 0.54f)
        {
            judgementTextTest.GetComponent<Text>().text = "Alive";
            Destroy(note);
        }
        else if(touchElapsedTime > 0.54f && touchElapsedTime <= 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Late Choice";
            Destroy(note);
        }
        else if(touchElapsedTime > 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            Destroy(note);
        }
        

        /*
        Collider2D judgementLineCollider = judgementLine.GetComponent<Collider2D>();

        if (judgementLineCollider != null)
        {
            // 충돌한 Collider를 저장할 배열
            Collider2D[] overlappingJudgementColliders = new Collider2D[10]; 

            ContactFilter2D contactFilter = new ContactFilter2D().NoFilter();

            int count = judgementLineCollider.OverlapCollider(contactFilter, overlappingJudgementColliders);

            // 같은 부모를 가진 콜라이더들만 검사
            int validCount = 0;
            for (int i = 0; i < count; i++)
            {
                Collider2D overlappingCollider = overlappingJudgementColliders[i];
                if (overlappingCollider.transform.parent == judgementLine.transform.parent)
                {
                    Debug.Log("good");
                    overlappingJudgementColliders[validCount] = overlappingCollider;
                    //Debug.Log("Overlapping UI Element: " + overlappingJudgementColliders[validCount]);
                    validCount++;
                }

            }


            // if(count == 2)
            // {
            //     Debug.Log("Dead");
            //     judgementTextTest.GetComponent<Text>().text = "Dead";
            // }

            // 판정선과 겹치는 콜라이더의 개수에 따라 판정
            if(validCount == 2 || validCount == 3)
            {
                Debug.Log("Early Choice");
                judgementTextTest.GetComponent<Text>().text = "Early Choice";
            }
            
            else if(validCount == 4)
            {
                Debug.Log("Alive");
                judgementTextTest.GetComponent<Text>().text = "Alive";
            }

            else if(validCount == 5)
            {
                Debug.Log("Late Choice");
                judgementTextTest.GetComponent<Text>().text = "Late Choice";
            }
            

            Destroy(normalNote);
            
        }
        */
        
    }

    private void RemoveObject()
    {
        judgementTextTest.GetComponent<Text>().text = "Dead";
        Destroy(note); // 현재 오브젝트를 삭제합니다.
    }

}
