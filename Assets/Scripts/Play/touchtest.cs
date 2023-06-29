using UnityEngine;
using UnityEngine.EventSystems;

public class touchtest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // 터치가 시작될 때 처리
        Debug.Log("Touch Down on UI Element: " + gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 터치가 종료될 때 처리
        Debug.Log("Touch Up on UI Element: " + gameObject.name);
    }
}