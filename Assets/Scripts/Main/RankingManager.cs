using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RankingManager : MonoBehaviour
{
    public GameObject rankItemPrefab;
    public GameObject rankPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartRank(string songId, string songDifficulty)
    {
        string songIDWithDifficulty = songManager.Instance.MakeIdWithDifficulty(songId,songDifficulty);
        StartCoroutine(GetAndShowRankData(songIDWithDifficulty));
    }

    IEnumerator GetAndShowRankData(string songIDWithDifficulty)
    {
        string url = Constants.HOST+ "score/" + songIDWithDifficulty;
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.error != null)
        {
            Debug.Log(www.error);
            www.Dispose();
            yield break;
        }
        
        Debug.Log(www.downloadHandler.text);
        Ranks rankData = JsonUtility.FromJson<Ranks>(www.downloadHandler.text);

        // rankPanel의 모든 자식들, 즉 랭킹의 항목들을 전부 삭제하여 rankPanel 초기화
        for (int i = rankPanel.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = rankPanel.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        // rankPanel에 랭킹 항목의 개수만큼 랭킹 항목 생성 후 데이터 삽입
        for(int i = 0; i < rankData.ranks.Length; i++)
        {
            // 랭크 항목 프리팹으로 랭크 항목 생성
            GameObject rankItem= Instantiate(rankItemPrefab);

            // 랭크 항목 프리팹에서 요소들을 찾아서 저장
            GameObject rankNum = rankItem.transform.Find("RankPlaceImage").GetChild(0).gameObject;
            GameObject rankUserName = rankItem.transform.Find("RankUserName").gameObject;
            GameObject rankUserScore = rankItem.transform.Find("RankUserScore").gameObject;
            GameObject rankUserProgressImage = rankItem.transform.Find("RankUserProgressImage").gameObject;
            GameObject rankUserRankImage = rankItem.transform.Find("RankUserRankImage").gameObject;

            // 전달 받아온 데이터를 프리팹으로 만든 오브젝트의 요소들에 설정 (등수, 닉네임, 점수, 달성도, 랭크)
            rankNum.GetComponent<Text>().text = rankData.ranks[i].rank;
            rankUserName.GetComponent<Text>().text = rankData.ranks[i].nickname;
            rankUserScore.GetComponent<Text>().text = rankData.ranks[i].score;
            rankUserProgressImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/SongProgressImage" + rankData.ranks[i].progress);

            if(int.Parse(rankData.ranks[i].score) >= 990000f)
            {
                rankUserRankImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageSplus");
            }
            else if(990000f > int.Parse(rankData.ranks[i].score) && int.Parse(rankData.ranks[i].score) >= 980000f)
            {
                rankUserRankImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImage");
            }
            else if(980000f > int.Parse(rankData.ranks[i].score) && int.Parse(rankData.ranks[i].score) >= 950000f)
            {
                rankUserRankImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageAplus");
            }
            else if(950000f > int.Parse(rankData.ranks[i].score) && int.Parse(rankData.ranks[i].score) >= 920000f)
            {
                rankUserRankImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageA");
            }
            else if(920000f > int.Parse(rankData.ranks[i].score) && int.Parse(rankData.ranks[i].score) >= 890000f)
            {
                rankUserRankImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageB");
            }
            else if(890000f > int.Parse(rankData.ranks[i].score))
            {
                rankUserRankImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play/UI/RankImageC");
            }

            // 생성되고 정보가 입력된 오브젝트들의 부모를 랭킹 패널로 지정하여 보이게 함
            rankItem.transform.SetParent(rankPanel.transform, false);
        }
    
        www.Dispose();
    }

    
}
