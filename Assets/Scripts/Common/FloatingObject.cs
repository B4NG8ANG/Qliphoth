using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatSpeed = 1.0f; // 오브젝트의 상하 움직임 속도 조절
    public float floatRange; // 움직임 범위 조절

    private Vector3 initialPosition;
    private float timeOffset;

    private void Start()
    {
        // 오브젝트의 초기 위치를 저장합니다.
        initialPosition = transform.position;

        // 랜덤한 시작 시간 오프셋을 생성합니다.
        //timeOffset = Random.Range(0f, 2f * Mathf.PI);
        
        timeOffset = 0f;
    }

    private void Update()
    {
        // 오브젝트를 위아래로 움직이는 로직을 구현합니다.
        float newYPosition = initialPosition.y + Mathf.Sin((Time.time + timeOffset) * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
