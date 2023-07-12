using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// with Goongam Goongam Goongam
public class LongNoteJudgementManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // playManager 스크립트를 참조하기 위한 변수
    private playManager playManagerScript;

    // 판정선 시작, 목표 크기, 감소 애니메이션 지속 시간
    public Vector3 judgementLineStartScale;
    public Vector3 judgementLineTargetScale;
    public float judgementLineComingDuration;

    // 스크립트 시작 시각
    private float startTime;

    // 판정선 transform
    private Transform judgementLineTransform; 

    // 판정선, 노트, 판정 텍스트, 콤보 테스트 오브젝트
    public GameObject judgementLine;
    public GameObject note; 
    GameObject judgementTextTest;
    GameObject comboTest;

    // 노트가 삭제되기까지 걸리는 시간 (노트 오브젝트 지속 시간)
    public float noteDeletingTime;

    // 노트가 최초로 터치된 시각
    float startTouchTime = 0;

    float prevCombingTime; // 마지막으로 계산된 콤보가 올라간 시각
    float touchElapsedTime; // 판정선이 생기고 난 뒤 흐른 시간

    // 롱노트 콤보의 최대치를 제한하기 위한 변수
    int comboLimit = 0;

    // 터치가 되고 있는지 감지하는 변수
    public bool touched = false;



    
    void Start()
    {
        // 판정선 transform 저장
        judgementLineTransform = judgementLine.transform;

        judgementTextTest = GameObject.Find("JudgementTextTest");
        //comboTest = GameObject.Find("ComboTest");

        // 시작 시각 저장
        startTime = Time.time;

        // playManager라는 컴포넌트를 가진 오브젝트중 제일 처음 것을 찾고, 그 컴포넌트를 참조 
        playManagerScript = FindObjectOfType<playManager>();
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

        // 노트가 터치되고 있을때 지나가는 시간
        // 현재 시각에서 롱 노트를 처음 터치한 시각을 뺀 시각으로, 매 프레임마다 계산되어 늘어남
        float touchingTime = Time.time - startTouchTime;

        // 터치가 한번도 되지 않은 상태로 롱노트 지속시간이 초과되면 Dead 판정 후 삭제
        if(!touched && elapsedTime > noteDeletingTime)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            playManagerScript.AddCombo(false);
            gameObject.SetActive(false);
        }

        // 롱 노트 지속시간이 초과되면 Alive 판정 후 삭제
        if(touched && Time.time >= noteDeletingTime)
        {
            judgementTextTest.GetComponent<Text>().text = "Alive";
            playManagerScript.AddCombo(true);
            gameObject.SetActive(false);
            return;
        }

        // 터치를 한번이라도 한 상태에서 터치를 진행중인 시간이 0 이상일 경우 0.2초에 한번씩 콤보 적립
        // 롱 노트에서 손을 뗐을 경우 OnPointerUp()이 호출 됐을것이고, 처음부터 한번도 터치하지 않았다면 그냥 현재 시각
        else if(touchingTime > 0)
        {
          
            // 롱노트 하나로 쌓을수 있는 콤보의 최대치 제한
            // 터치 시점이 달라도 일관성 있는 콤보 수 제공 가능
            if(comboLimit >= Mathf.FloorToInt((noteDeletingTime - 0.45f) / 0.2f - 1f))
            {
                return;
            }

            // 콤보가 추가되는 시각 (prevCombingTime에 저장된 오차 값 만큼 빨라짐)
            float combingTime = Time.time - prevCombingTime;

            // 콤보 시간 오차 값
            float delayCombingTime = combingTime - 0.2f;

            if(combingTime >= 0.2)
            {
                // 콤보가 쌓여야 하는 시점에 터치 중일때 콤보 쌓음
                if(touched)
                {
                    Debug.Log(combingTime);
                    judgementTextTest.GetComponent<Text>().text = "Alive";
                    playManagerScript.AddCombo(true);

                    // 판정 애니메이션 여기에 출력
                        
                        
                }
                // 콤보가 쌓여야 하는 시점에 터치 하고 있지 않으면 콤보 초기화
                else if(!touched)
                {
                    Debug.Log(combingTime);
                    Debug.Log("Dead");
                    judgementTextTest.GetComponent<Text>().text = "Dead";
                    playManagerScript.AddCombo(false);

                    // 판정 애니메이션 여기에 출력
                        
                       
                }

                // 오차 값을 prevCombingTime에 저장
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
            playManagerScript.AddCombo(true);
        }
        else if(touchElapsedTime >= 0.45f && touchElapsedTime <= 0.55f)
        {
            judgementTextTest.GetComponent<Text>().text = "Alive";
            playManagerScript.AddCombo(true);
        }
        else if(touchElapsedTime > 0.55f && touchElapsedTime <= 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Late Choice";
            playManagerScript.AddCombo(true);
        }
        else if(touchElapsedTime > 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            playManagerScript.AddCombo(false);
        }
        
        // 롱노트 차는 애니메이션 재생
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        judgementTextTest.GetComponent<Text>().text = "Dead";
        playManagerScript.AddCombo(false);
        gameObject.SetActive(false);
    }

}
