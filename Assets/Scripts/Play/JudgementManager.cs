using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JudgementManager : MonoBehaviour, IPointerDownHandler
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

    // 노트가 삭제되기까지 걸리는 시간 (노트 오브젝트 지속 시간)
    public float noteDeletingTime;

    // 터치를 했는지 감지하는 변수
    public bool touched = false;

    // 이펙트 이미지 테스트
    public GameObject noteEffectTest;

    // 노트가 보일 패널
    GameObject notePanel;

    
    void Start()
    {
        // 판정선 transform 저장
        judgementLineTransform = judgementLine.transform;

        // 판정 텍스트 오브젝트 저장 (임시)
        judgementTextTest = GameObject.Find("JudgementTextTest");

        notePanel = GameObject.Find("NotePanel");

        // 시작 시간 저장
        startTime = Time.time;

        // playManager라는 컴포넌트를 가진 오브젝트중 제일 처음 것을 찾고, 그 컴포넌트를 참조 
        playManagerScript = FindObjectOfType<playManager>();

        noteEffectTest.SetActive(false);
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

        // 터치 되지 않은채로 노트 지속시간이 경과되면 Dead 판정 후 삭제
        if(!touched && elapsedTime > noteDeletingTime)
        {
            judgementTextTest.GetComponent<Text>().text = "Dead";
            playManagerScript.AddCombo(false);
            Invoke("RemoveNote", 0.3f);
        }
        
    }

    // 노트 터치
    public void OnPointerDown(PointerEventData eventData)
    {
        touched = true;
        float touchElapsedTime = Time.time - startTime;
        Debug.Log(touchElapsedTime);

        if(touchElapsedTime < 0.45f)
        {
            judgementTextTest.GetComponent<Text>().text = "Early Choice";
            playManagerScript.AddCombo(true);
            Invoke("RemoveNote", 0.3f);
            noteEffectTest.SetActive(true);
        }
        else if(touchElapsedTime >= 0.45f && touchElapsedTime <= 0.55f)
        {
            judgementTextTest.GetComponent<Text>().text = "Alive";
            playManagerScript.AddCombo(true);
            Invoke("RemoveNote", 0.3f);
            noteEffectTest.SetActive(true);
        }
        else if(touchElapsedTime > 0.55f && touchElapsedTime <= 0.8f)
        {
            judgementTextTest.GetComponent<Text>().text = "Late Choice";
            playManagerScript.AddCombo(true);
            Invoke("RemoveNote", 0.3f);
            noteEffectTest.SetActive(true);
        }
        // else if(touchElapsedTime > 0.8f)
        // {
        //     judgementTextTest.GetComponent<Text>().text = "Dead";
        //     playManagerScript.AddCombo(false);
        //     Invoke("RemoveNote", 0.3f);
        //     noteEffectTest.SetActive(true);
        // }
    }

    private void RemoveNote()
    {
        gameObject.SetActive(false);
    }

}
