using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class songManager
{
    //싱글톤
    private static songManager instance = null;

    public static songManager Instance{
        get {
            if(instance == null){
                instance = new songManager();
            }

            return instance;
        }
    }

    public Song[] song;

    public void Init()
    {
        // 각 곡과 난이도에 맞는 채보 저장
        Note[] FractureRay1Normal4 = new Note[]{
            new Note("longNote", "1.0", "(300,300,0)", "0", "false", "1.0"),
            new Note("normalNote", "2.1", "(700,700,0)", "1", "false", ""),
            new Note("normalNote", "2.11", "(800,800,0)", "2", "false", ""),
            new Note("normalNote", "2.12", "(600,600,0)", "3", "false", ""),
            new Note("normalNote", "2.13", "(500,500,0)", "4", "false", ""),
            new Note("normalNote", "2.14", "(400,400,0)", "5", "false", ""),
            new Note("normalNote", "2.15", "(300,300,0)", "6", "false", ""),
            new Note("longNote", "5.0", "(600,600,0)", "7", "false", "5.0")
        };

        Note[] FractureRay1Hard6 = new Note[]{
            new Note("normalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("longNote", "2.0", "(700,700,0)", "1", "false", "2.0"),
            new Note("normalNote", "5.0", "(600,600,0)", "2", "false", "")
        };

        Note[] FractureRay1Death10 = new Note[]{
            new Note("normalNote", "1.0", "(0,300,0)", "0", "false", ""),
            new Note("smallNormalNote", "2.0", "(1920,300,0)", "1", "false", ""),
            new Note("slideNote", "3.0", "(100,500,0)", "2", "false", ""),
            new Note("slideNote", "4.0", "(500,500,0)", "3", "false", ""),
            new Note("longNote", "5.0", "(600,500,0)", "4", "false", "1.0"),
            new Note("bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""),
            new Note("normalNote", "7.0", "(800,200,0)", "6", "false", ""),
            new Note("normalNote", "9.0", "(900,200,0)", "7", "true", ""),
            new Note("normalNote", "10.0", "(700,400,0)", "9", "false", ""),
            new Note("slideNote", "11.0", "(800,500,0)", "10", "false", ""),
            new Note("slideNote", "11.1", "(900,600,0)", "11", "false", ""),
            new Note("slideNote", "11.2", "(1000,700,0)", "12", "false", "")
        };

        Note[] CytusII1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(960,540,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(960,-540,0)", "1", "false", ""),
            new Note("slideNote", "3.0", "(-960,540,0)", "2", "false", ""),
            new Note("slideNote", "4.0", "(-960,-540,0)", "3", "false", "")
        };

        Note[] CytusII1Hard3 = new Note[]{
            new Note("smallNormalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("bigNormalNote", "5.0", "(600,600,0)", "1", "false", ""),
            new Note("normalNote", "6.0", "(800,800,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", ""),
            new Note("normalNote", "8.0", "(800,600,0)", "4", "false", "")
        };

        Note[] CytusII1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Conversationswithstrangers1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Conversationswithstrangers1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Conversationswithstrangers1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };


        song = new Song[]{
            new Song("0", "Fracture Ray", "Sakuzyo", 4, 6, 10, FractureRay1Normal4, FractureRay1Hard6, FractureRay1Death10),
            new Song("1", "Cytus II", "Cytus II", 1, 3, 5, CytusII1Normal1, CytusII1Hard3, CytusII1Death5),
            new Song("2", "Conversations with strangers", "Caitlin Cook", 1, 3, 5, Conversationswithstrangers1Normal1, Conversationswithstrangers1Hard3, Conversationswithstrangers1Death5)
        };
    }

    // id를 사용하여 곡을 찾는 함수
    public Song getSongbyId(string id){
        Song findsong = null;
        foreach (var songData in song)
        {
            if(songData.id == id) findsong = songData;
        }

        return findsong;
    }

    // 곡 난이도가 포함된 ID를 생성
    public string MakeIdWithDifficulty(string songID, string songDifficulty)
    {
        return songID + "_" + songDifficulty;
    }


    // 로그인 시 로컬 기록과 서버 기록을 비교 후 갱신하는 함수
    public IEnumerator loginPlayRecordUpdate()
    {
        // URL 저장
        Debug.Log(Constants.HOST+ "score/" + AuthManager.Instance.UserId);
        string url = Constants.HOST+ "score/" + AuthManager.Instance.UserId;
        
        // URL에 접속
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.error != null)
        {
            Debug.Log(www.error);
            www.Dispose();
            yield break;
        }
        
        // recordData 배열 안에 서버에 저장되어 있던 기록을 저장
        Debug.Log(www.downloadHandler.text);
        Records recordData = JsonUtility.FromJson<Records>(www.downloadHandler.text);

        // 로그인 시에 서버에 저장되어 있던 기록과 로컬에 저장되어 있던 기록을 비교  
        for(int i = 0; i < song.Length; i++)
        {
            for(int j = 0; j < recordData.records.Length; j++)
            {
                // 서버에 점수 기록이 있음 (서버에 기록이 없다면 아무 일도 일어나지 않음)
                if(MakeIdWithDifficulty(song[i].id, "Normal") == recordData.records[j].songID)
                {
                    // i) 서버에 점수 기록이 있고, 로컬에도 점수 기록이 있음
                    if(PlayerPrefs.HasKey("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty))
                    {
                        if(recordData.records[j].score >= int.Parse(PlayerPrefs.GetString("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty)))
                        {
                            PlayerPrefs.SetString("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty, recordData.records[j].score.ToString("0000000"));
                        }
                    }

                    // ii) 서버에 점수 기록이 있고, 로컬에는 점수 기록이 없음
                    else
                    {
                        PlayerPrefs.SetString("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty, recordData.records[j].score.ToString("0000000"));
                    }

                    // I) 서버에 달성도 기록이 있고, 로컬에도 달성도 기록이 있음
                    if(PlayerPrefs.HasKey("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty))
                    {
                        if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty) == "SongProgressImageClear")
                        {
                            if(recordData.records[j].progress == "FullCombo")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageFullCombo");
                            }
                            else if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                        else if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty) == "SongProgressImageFullCombo")
                        {
                            if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                    }

                    // II) 서버에 달성도 기록이 있고, 로컬에는 달성도 기록이 없음
                    else
                    {
                        if(recordData.records[j].progress == "Clear")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageClear");
                        }
                        else if(recordData.records[j].progress == "FullCombo")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageFullCombo");
                        }
                        else if(recordData.records[j].progress == "AllAlive")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageAllAlive");
                        }
                    }
                }

                // 서버에 기록이 있음 (서버에 기록이 없다면 아무 일도 일어나지 않음)
                if(MakeIdWithDifficulty(song[i].id, "Hard") == recordData.records[j].songID)
                {
                    // i) 서버에 기록이 있고, 로컬에도 기록이 있음
                    if(PlayerPrefs.HasKey("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty))
                    {
                        if(recordData.records[j].score >= int.Parse(PlayerPrefs.GetString("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty)))
                        {
                            PlayerPrefs.SetString("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty, recordData.records[j].score.ToString("0000000"));
                        }
                    }

                    // ii) 서버에 기록이 있고, 로컬에는 기록이 없음
                    else
                    {
                        PlayerPrefs.SetString("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty, recordData.records[j].score.ToString("0000000"));
                    }

                    // I) 서버에 달성도 기록이 있고, 로컬에도 달성도 기록이 있음
                    if(PlayerPrefs.HasKey("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty))
                    {
                        if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty) == "SongProgressImageClear")
                        {
                            if(recordData.records[j].progress == "FullCombo")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageFullCombo");
                            }
                            else if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                        else if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty) == "SongProgressImageFullCombo")
                        {
                            Debug.Log("good1");
                            if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                    }

                    // II) 서버에 달성도 기록이 있고, 로컬에는 달성도 기록이 없음
                    else
                    {
                        if(recordData.records[j].progress == "Clear")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageClear");
                        }
                        else if(recordData.records[j].progress == "FullCombo")
                        {
                            Debug.Log("good2");
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageFullCombo");
                        }
                        else if(recordData.records[j].progress == "AllAlive")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageAllAlive");
                        }
                    }
                }

                // 서버에 기록이 있음 (서버에 기록이 없다면 아무 일도 일어나지 않음)
                if(MakeIdWithDifficulty(song[i].id, "Death") == recordData.records[j].songID)
                {
                    // i) 서버에 기록이 있고, 로컬에도 기록이 있음
                    if(PlayerPrefs.HasKey("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty))
                    {
                        if(recordData.records[j].score >= int.Parse(PlayerPrefs.GetString("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty)))
                        {
                            PlayerPrefs.SetString("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty, recordData.records[j].score.ToString("0000000"));
                        }
                    }

                    // ii) 서버에 기록이 있고, 로컬에는 기록이 없음
                    else
                    {
                        PlayerPrefs.SetString("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty, recordData.records[j].score.ToString("0000000"));
                    }

                    // I) 서버에 달성도 기록이 있고, 로컬에도 달성도 기록이 있음
                    if(PlayerPrefs.HasKey("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty))
                    {
                        if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty) == "SongProgressImageClear")
                        {
                            if(recordData.records[j].progress == "FullCombo")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageFullCombo");
                            }
                            else if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                        else if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty) == "SongProgressImageFullCombo")
                        {
                            if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                    }

                    // II) 서버에 달성도 기록이 있고, 로컬에는 달성도 기록이 없음
                    else
                    {
                        if(recordData.records[j].progress == "Clear")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageClear");
                        }
                        else if(recordData.records[j].progress == "FullCombo")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageFullCombo");
                        }
                        else if(recordData.records[j].progress == "AllAlive")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageAllAlive");
                        }
                    }
                }
            }
        }

        
        
        
    }

    
}
