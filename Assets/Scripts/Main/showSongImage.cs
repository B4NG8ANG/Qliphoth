using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class showSongImage : MonoBehaviour, IPointerClickHandler
{
    public Image targetImage; // 이동시킬 대상 이미지
    public float moveSpeed; // 이미지 이동 속도
    public float targetX; // 목표 X 좌표

    private bool isMoving = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        // 곡 선택 아이콘 이미지 변경
        if (gameObject.GetComponent<Image>().sprite.name == "SongSelectButtonImage")
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SelectedSongSelectButtonImage");
        }
        else if (gameObject.GetComponent<Image>().sprite.name == "SelectedSongSelectButtonImage")
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SongSelectButtonImage");
        }

        // 곡 이미지 움직이는 함수 호출
        if (!isMoving)
        {
            StartCoroutine(MoveImage());
        }
    }

    // 곡 이미지를 움직여 마스크 안에 보이게 하는 함수
    private IEnumerator MoveImage()
    {
        isMoving = true;

        // 곡 이미지가 노출 되어있을때 다시 클릭시 곡 이미지 숨김
        if (gameObject.GetComponent<Image>().sprite.name == "SongSelectButtonImage")
        {
            while (targetImage.rectTransform.anchoredPosition.x >= -275f)
            {
                // FixedUpdate는 함수 간의 시간 간격을 나타냄
                float step = moveSpeed * Time.fixedDeltaTime;
                targetImage.rectTransform.anchoredPosition -= Vector2.right * step;

                // WaitForFixedUpdate()는 물리적인 연산이 업데이트되는 FixedUpdate 프레임마다 코루틴이 중단되고 재개됨
                yield return new WaitForFixedUpdate();
            }
        }
        // 곡 이미지가 숨겨져 있을때 클릭시 곡 이미지 노출
        else if (gameObject.GetComponent<Image>().sprite.name == "SelectedSongSelectButtonImage")
        {
            while (targetImage.rectTransform.anchoredPosition.x <= targetX)
            {
                float step = moveSpeed * Time.fixedDeltaTime;
                targetImage.rectTransform.anchoredPosition += Vector2.right * step;
                yield return new WaitForFixedUpdate();
            }
        }

        isMoving = false;
    }
}

