using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// with Goongam Goongam Goongam
public class LongNoteJudgementManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 judgementLineStartScale; // 판정선 시작 크기
    public Vector3 judgementLineTargetScale; // 판정선 목표 크기
    public float judgementLineComingDuration; // 판정선 감소 애니메이션 시간
    private float startTime; // 스크립트 시작 시각
    private Transform judgementLineTransform; // 판정선 transform

    public GameObject judgementLine;  // 판정선 오브젝트
    public GameObject note; // 노트 오브젝트
    GameObject judgementTextTest; // 판정 텍스트 오브젝트
    GameObject comboTest; // 콤보 테스트 오브젝트
    public float noteDeletingTime; // 노트 삭제 시간

    float startTouchTime = 0; // 노트가 터치된 시각
    // float touchingTime 노트가 터치되고 있을때 지나가는 시간
    // float combingTime 콤보가 올라가는 시간 간격
    float prevCombingTime; // 마지막으로 계산된 콤보가 올라간 시각
    float touchElapsedTime; // 판정선이 생기고 난뒤 흐른 시간

    int combo = 0;

    // 터치가 되고 있는지 감지하는 변수
    public bool touched = false;



    
    void Start()
    {
        // 롱노트에서는 처리 안된 노트가 사라지게하는 Invoke문 필요 없음
        // Invoke("RemoveNote", noteDeletingTime);
        

        // 판정선 transform 저장
        judgementLineTransform = judgementLine.transform;

        judgementTextTest = GameObject.Find("JudgementTextTest");
        comboTest = GameObject.Find("ComboTest");

        // 시작 시각 저장
        startTime = Time.time;
    }

    void Update()
    {
        // 경과 시간 계산
        float elapsedTime = Time.time - startTime;
        // 시간 비율 (0 ~ 1) 
        float t = Mathf.Clamp01(elapsedTime / judgementLineComingDuration); 

        // 판정선 시작 크기에서 목표 크기로 보간
        Vector3 currentScale = Vector3.Lerp(judgementLineStartScale, judgementLineTargetScale, t);

        // 판정선 크기를 적용 (작아짐)
        judgementLineTransform.localScale = currentScale;

        /*
        // 애니메이션이 종료되면 스크립트 비활성화
        if (t >= 1f)
        {
            enabled = false;
        }
        */

        float touchingTime = Time.time - startTouchTime;

        if(!touched && elapsedTime > noteDeletingTime)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            Debug.Log("elapsedTime");
            Destroy(note);
        }

        if(touched && touchingTime >= noteDeletingTime)
        {
            Debug.Log("touchingTime");
            judgementTextTest.GetComponent<Text>().text = "Alive";
            Destroy(note);
            return;
        }

        else if(touched && touchingTime > 0)
        {
            // 콤보 고점 억제
            if(combo >= Mathf.FloorToInt((noteDeletingTime - 0.45f) / 0.2f - 1f))
            {
                return;
            }

            //Debug.Log(noteDeletingTime / 0.2f - 1f);

            //judgementTextTest.GetComponent<Text>().text = "Alive";

            // 콤보 쌓임
            float combingTime = Time.time - prevCombingTime;

            // 콤보 시간 오차 값
            float delayCombingTime = combingTime - 0.2f;
            if(combingTime >= 0.2)
            {
                // playManager에 addCombo() 함수 구현 후 addCombo(); 호출
                combo = combo + 1;
                
                //Debug.Log(combo);
                comboTest.GetComponent<Text>().text = combo.ToString();
                prevCombingTime = Time.time - delayCombingTime;
            }

            

        }
        
    }


    // 노트 터치
    public void OnPointerDown(PointerEventData eventData)
    {
        startTouchTime = Time.time;
        prevCombingTime = startTouchTime;
        touchElapsedTime = startTouchTime - startTime;

        touched = true;

        if(touchElapsedTime < 0.45f)
        {
            judgementTextTest.GetComponent<Text>().text = "Early Choice";
            //Destroy(note);
        }
        else if(touchElapsedTime >= 0.45f && touchElapsedTime <= 0.55f)
        {
            judgementTextTest.GetComponent<Text>().text = "Alive";
            //Destroy(note);
        }
        else if(touchElapsedTime > 0.55f && touchElapsedTime <= 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Late Choice";
            //Destroy(note);
        }
        else if(touchElapsedTime > 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            //Destroy(note);
        }
        
        // 롱노트 차는 애니메이션 재생
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        judgementTextTest.GetComponent<Text>().text = "Dead";
        Destroy(note);
    }


    // 롱노트에서는 처리 안된 노트가 사라지게하는 Invoke문 필요 없음
    // private void RemoveNote()
    // {
    //     judgementTextTest.GetComponent<Text>().text = "Alive";
    //     Destroy(note); // 현재 오브젝트를 삭제합니다.
    //     touched = false;
    // }

}
