using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JudgementManager : MonoBehaviour, IPointerDownHandler
{
    public float shrinkAmount;  // 크기 감소량
    public GameObject judgementLine;  // 판정선 오브젝트
    public GameObject normalNote; // 노트 오브젝트

    
    void Start()
    {
        
    }

   
    void Update()
    {
        // 크기를 감소시킴
        Vector3 newScale = judgementLine.transform.localScale - new Vector3(shrinkAmount, shrinkAmount, 0f);

        // 크기를 적용
        judgementLine.transform.localScale = newScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 터치가 시작될 때 처리
        //Destroy(normalNote);

       // 터치한 UI 요소
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        // UI 요소와 겹치는 모든 UI 요소들의 이름 출력
        GraphicRaycaster raycaster = clickedObject.GetComponentInParent<GraphicRaycaster>();
        if (raycaster != null)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = eventData.position;

            // UI 요소와 겹치는 모든 UI 요소들 검색
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                GameObject overlappingObject = result.gameObject;
                Debug.Log("Overlapping UI Element: " + overlappingObject.name);
            }
        }
        
    }
}
