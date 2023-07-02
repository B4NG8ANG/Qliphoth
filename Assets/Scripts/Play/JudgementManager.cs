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
    public GameObject judgementTextTest; // 판정 텍스트 오브젝트
    public float delayInSeconds = 3f; // 노트 삭제 시간

    
    void Start()
    {
        Invoke("RemoveObject", delayInSeconds);
    }

    void Update()
    {
        // 크기를 감소시킴
        Vector3 newScale = judgementLine.transform.localScale - new Vector3(shrinkAmount, shrinkAmount, 0f);

        // 크기를 적용
        judgementLine.transform.localScale = newScale;
    }

    // 노트 터치
    public void OnPointerDown(PointerEventData eventData)
    {
        
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
        
    }

    private void RemoveObject()
    {
        Destroy(normalNote); // 현재 오브젝트를 삭제합니다.
    }

}
