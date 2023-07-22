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

    // 스크립트 시작 후 경과 시간
    private float elapsedTime;

    // 판정선 transform
    private Transform judgementLineTransform;

    // 판정선, 노트, 판정 텍스트, 콤보 테스트 오브젝트
    public GameObject judgementLine;
    public GameObject note; 
    GameObject judgementTextTest;
    GameObject comboTest;

    // 노트가 삭제되기까지 걸리는 시간 (노트 오브젝트 지속 시간)
    public float noteDeletingTime;

    // 판정선이 생기고 난 뒤 흐른 시간
    public float touchElapsedTime; 

    // 터치가 되고 있는지 감지하는 플래그 변수
    public bool touched = false;

    // 롱 노트의 처리가 끝났는지 감지하는 플래그 변수
    public bool isLongNote = true;

    // 롱노트의 판정 상태를 저장 할 변수
    public string longNoteJudgement;

    // 이펙트 이미지 오브젝트
    public GameObject noteEffectFirst;
    public GameObject noteEffectSecond;



    
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

        noteEffectFirst.SetActive(false);
        noteEffectSecond.SetActive(false);
    }

    void Update()
    {
        // 경과 시간 계산
        elapsedTime = Time.time - startTime;
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

        // 터치가 한번도 되지 않은 상태로 롱 노트 지속시간이 초과되면 Dead 판정 후 삭제
        if(!touched && elapsedTime >= noteDeletingTime)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            playManagerScript.AddCombo(false);
            Invoke("RemoveNote", 0.3f);
        }

        // 터치가 한번이라도 된 채로 롱 노트 지속시간이 초과되면 판정 후 삭제
        else if(touched && elapsedTime >= noteDeletingTime && isLongNote)
        {
            // Invoke가 불러와지는 0.3초동안 실행되지 않도록 플래그 변경
            isLongNote = false;

            // 판정 텍스트 표시
            judgementTextTest.GetComponent<Text>().text = longNoteJudgement;

            if(longNoteJudgement == "Early Choice")
            {
                playManagerScript.CountJudgement("early");
                playManagerScript.AddScore(false);
            }
            else if(longNoteJudgement == "Alive")
            {
                playManagerScript.CountJudgement("alive");
                playManagerScript.AddScore(true);
            }
            else if(longNoteJudgement == "Late Choice")
            {
                playManagerScript.CountJudgement("late");
                playManagerScript.AddScore(false);
            }
            
            noteEffectSecond.SetActive(true);
            playManagerScript.AddCombo(true);
            Invoke("RemoveNote", 0.3f);
            return;
        }


    }

    // 노트 터치
    public void OnPointerDown(PointerEventData eventData)
    {
        // 노트 지속시간이 경과되면 터치 이벤트를 무시
        if (elapsedTime >= noteDeletingTime)
        {
            return;
        }

        // 노트를 터치한 적이 있으면 터치 이벤트를 무시
        if (touched)
        {
            return;
        }

        touchElapsedTime = Time.time - startTime;
        touched = true;

        if(touchElapsedTime < 0.45f)
        {
            longNoteJudgement = "Early Choice";
            noteEffectFirst.SetActive(true);
        }
        else if(touchElapsedTime >= 0.45f && touchElapsedTime <= 0.55f)
        {
            longNoteJudgement = "Alive";
            noteEffectFirst.SetActive(true);
        }
        else if(touchElapsedTime > 0.55f) // && touchElapsedTime <= 0.8f)
        {
            longNoteJudgement = "Late Choice";
            noteEffectFirst.SetActive(true);
        }
        // else if(touchElapsedTime > 0.8f)
        // {
        //     judgementTextTest.GetComponent<Text>().text = "Dead";
        //     playManagerScript.AddCombo(false);
        // }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 노트 지속시간이 경과되면 터치 중지 이벤트를 무시
        if (elapsedTime >= noteDeletingTime)
        {
            return;
        }

        judgementTextTest.GetComponent<Text>().text = "Dead";
        playManagerScript.AddCombo(false);
        Invoke("RemoveNote", 0.3f);
        noteEffectFirst.SetActive(false);
    }

    private void RemoveNote()
    {
        gameObject.SetActive(false);
    }
}
