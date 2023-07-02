using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NoteManager : MonoBehaviour
{
    // 노트 오브젝트 컨테이너
    public GameObject normalNote;
    // 노트 영역
    public GameObject noteRect;
    


    private void Update()
    {
       
    }
    
    // // 판정선이 노트의 끝까지 도달하면 노트 삭제
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // 부딪힌 오브젝트의 이름 가져오기
    //     string collidedObjectName = collision.gameObject.name;

    //     // 같은 노트의 판정선인지 검사
    //     if(collision.transform.parent == noteRect.transform.parent)
    //     {
    //         // 판정선에 닿으면 노트 오브젝트 삭제
    //         if (collidedObjectName == "JudgmentLine")
    //         {
    //             Destroy(normalNote);
    //         }
    //     }

    // }
    
    
    

}
