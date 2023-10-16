using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatSpeed = 1.0f; // 오브젝트의 상하 움직임 속도 조절
    public float floatRange; // 움직임 범위 조절

    private Vector3 initialPosition;
    private float timeOffset;

    private bool isDown = false;
    private float distance = 0f;
    private void Start()
    {
        // 오브젝트의 초기 위치를 저장합니다.
        initialPosition = transform.localPosition;

        // 랜덤한 시작 시간 오프셋을 생성합니다.
        //timeOffset = Random.Range(0f, 2f * Mathf.PI);
        
        timeOffset = 0f;
    }

    private void FixedUpdate() {
        
    
        //움직이는 속도
        if(isDown){
            distance -= 0.01f; //아래로 움직이는 속도 (0.001f)
        }else{
            distance += 0.01f; //위로 움직이는 속도 (0.001f)
        }

        //범위
        if(distance <= -0.4f) isDown = false; //최대 아래 범위 (0.1f)
        else if(distance >= 0.4f) isDown = true; //최대 위 범위 (0.1f)

        initialPosition.y = initialPosition.y - distance;
        transform.transform.localPosition = initialPosition;
    }
}
