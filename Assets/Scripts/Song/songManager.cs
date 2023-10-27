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
        Note[] High1Normal4 = new Note[]{
            new Note("longNote", "1.0", "(300,300,0)", "0", "false", "1.0"),
            new Note("normalNote", "2.1", "(700,700,0)", "1", "false", ""),
            new Note("normalNote", "2.11", "(800,800,0)", "2", "false", ""),
            new Note("normalNote", "2.12", "(600,600,0)", "3", "false", ""),
            new Note("normalNote", "2.13", "(500,500,0)", "4", "false", ""),
            new Note("normalNote", "2.14", "(400,400,0)", "5", "false", ""),
            new Note("normalNote", "2.15", "(300,300,0)", "6", "false", ""),
            new Note("longNote", "5.0", "(600,600,0)", "7", "false", "5.0")
        };

        Note[] High1Hard6 = new Note[]{
            new Note("normalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("longNote", "2.0", "(700,700,0)", "1", "false", "2.0"),
            new Note("normalNote", "5.0", "(600,600,0)", "2", "false", "")
        };

        Note[] High1Death10 = new Note[]{
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

        Note[] TheLight1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(960,540,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(960,-540,0)", "1", "false", ""),
            new Note("slideNote", "3.0", "(-960,540,0)", "2", "false", ""),
            new Note("slideNote", "4.0", "(-960,-540,0)", "3", "false", "")
        };

        Note[] TheLight1Hard3 = new Note[]{
            new Note("smallNormalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("bigNormalNote", "5.0", "(600,600,0)", "1", "false", ""),
            new Note("normalNote", "6.0", "(800,800,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", ""),
            new Note("normalNote", "8.0", "(800,600,0)", "4", "false", "")
        };

        Note[] TheLight1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] TooHotToHandle1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] TooHotToHandle1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] TooHotToHandle1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] YouDidMeWrong1Normal5 = new Note[]{
            new Note("normalNote","2.56","(-540,192,0)","0","false","0.0"),
            new Note("normalNote","2.80","(-447,-164,0)","1","false","0.0"),
            new Note("normalNote","3.02","(87,184,0)","2","false","0.0"),
            new Note("normalNote","3.31","(345,-211,0)","3","false","0.0"),
            new Note("normalNote","3.61","(698,234,0)","4","false","0.0"),
            new Note("normalNote","6.26","(-644,152,0)","5","false","0.0"),
            new Note("normalNote","6.54","(-462,-123,0)","6","false","0.0"),
            new Note("normalNote","6.88","(-41,122,0)","7","false","0.0"),
            new Note("normalNote","7.31","(225,-216,0)","8","false","0.0"),
            new Note("normalNote","7.79","(642,79,0)","9","false","0.0"),
            new Note("normalNote","9.18","(-617,301,0)","10","false","0.0"),
            new Note("normalNote","9.65","(-158,-11,0)","11","false","0.0"),
            new Note("normalNote","10.49","(618,-281,0)","12","false","0.0"),
            new Note("normalNote","13.23","(686,316,0)","13","false","0.0"),
            new Note("normalNote","13.88","(-28,-54,0)","14","false","0.0"),
            new Note("normalNote","14.58","(-601,-293,0)","15","false","0.0"),
            new Note("longNote","16.68","(-575,8,0)","16","false","2.0"),
            new Note("longNote","20.12","(706,-4,0)","17","false","2.0"),
            new Note("slideNote","25.49","(-516,202,0)","18","false","0.0"),
            new Note("slideNote","26.14","(28,199,0)","19","false","0.0"),
            new Note("slideNote","26.89","(729,192,0)","20","false","0.0"),
            new Note("slideNote","27.66","(684,-295,0)","21","false","0.0"),
            new Note("slideNote","28.31","(1,-299,0)","22","false","0.0"),
            new Note("slideNote","29.02","(-562,-295,0)","23","false","0.0"),
            new Note("normalNote","31.27","(-638,15,0)","24","false","0.0"),
            new Note("normalNote","31.56","(-688,15,0)","25","false","0.0"),
            new Note("normalNote","31.73","(-738,15,0)","26","false","0.0"),
            new Note("normalNote","31.98","(-788,15,0)","27","false","0.0"),
            new Note("normalNote","32.12","(-838,15,0)","28","false","0.0"),
            new Note("normalNote","32.55","(486,24,0)","29","false","0.0"),
            new Note("normalNote","33.05","(-802,-17,0)","30","false","0.0"),
            new Note("normalNote","34.74","(574,-1,0)","31","false","0.0"),
            new Note("normalNote","35.16","(574,-1,0)","32","false","0.0"),
            new Note("normalNote","35.37","(574,-1,0)","33","false","0.0"),
            new Note("normalNote","35.59","(574,-1,0)","34","false","0.0"),
            new Note("normalNote","35.75","(574,-1,0)","35","false","0.0"),
            new Note("normalNote","36.23","(-708,-4,0)","36","false","0.0"),
            new Note("normalNote","37.05","(663,10,0)","37","false","0.0"),
            new Note("normalNote","38.14","(-270,232,0)","38","false","0.0"),
            new Note("normalNote","38.75","(-252,-209,0)","39","false","0.0"),
            new Note("normalNote","39.19","(311,-220,0)","40","false","0.0"),
            new Note("normalNote","39.68","(327,236,0)","41","false","0.0"),
            new Note("normalNote","40.12","(327,236,0)","42","false","0.0"),
            new Note("normalNote","40.62","(318,-299,0)","43","false","0.0"),
            new Note("normalNote","41.10","(-369,-228,0)","44","false","0.0"),
            new Note("normalNote","41.51","(-313,248,0)","45","false","0.0"),
            new Note("slideNote","42.27","(-577,260,0)","46","false","0.0"),
            new Note("slideNote","42.60","(-226,-168,0)","47","false","0.0"),
            new Note("slideNote","42.90","(-81,-168,0)","48","false","0.0"),
            new Note("slideNote","43.33","(69,-171,0)","49","false","0.0"),
            new Note("slideNote","43.50","(247,-167,0)","50","false","0.0"),
            new Note("slideNote","44.20","(539,270,0)","51","false","0.0"),
            new Note("slideNote","45.88","(684,4,0)","52","false","0.0"),
            new Note("slideNote","46.86","(218,300,0)","53","false","0.0"),
            new Note("slideNote","47.22","(-57,300,0)","54","false","0.0"),
            new Note("slideNote","47.72","(-250,328,0)","55","false","0.0"),
            new Note("slideNote","48.21","(-550,290,0)","56","false","0.0"),
            new Note("slideNote","48.94","(-711,-51,0)","57","false","0.0"),
            new Note("longNote","51.34","(662,-1,0)","58","false","2.0"),
            new Note("smallNormalNote","51.89","(-508,215,0)","59","false","0.0"),
            new Note("smallNormalNote","52.42","(-474,-32,0)","60","false","0.0"),
            new Note("smallNormalNote","52.85","(-506,-264,0)","61","false","0.0"),
            new Note("longNote","54.59","(-569,-3,0)","62","false","2.0"),
            new Note("smallNormalNote","55.04","(481,255,0)","63","false","0.0"),
            new Note("smallNormalNote","55.57","(508,-22,0)","64","false","0.0"),
            new Note("smallNormalNote","56.09","(542,-347,0)","65","false","0.0"),
            new Note("normalNote","60.81","(-617,2,0)","66","true","0.0"),
            new Note("normalNote","60.81","(642,-3,0)","67","true","0.0"),
            new Note("normalNote","61.33","(-636,-1,0)","68","true","0.0"),
            new Note("normalNote","61.33","(626,-3,0)","69","true","0.0"),
            new Note("normalNote","63.71","(-631,5,0)","70","true","0.0"),
            new Note("normalNote","63.71","(663,-3,0)","71","true","0.0"),
            new Note("normalNote","64.21","(-654,0,0)","72","true","0.0"),
            new Note("normalNote","64.21","(663,-3,0)","73","true","0.0"),
            new Note("bigNormalNote","65.76","(-2,-3,0)","74","false","0.0"),
            new Note("slideNote","67.29","(-546,194,0)","75","false","0.0"),
            new Note("slideNote","67.61","(-442,28,0)","76","false","0.0"),
            new Note("slideNote","67.95","(-215,-198,0)","77","false","0.0"),
            new Note("slideNote","68.33","(81,-305,0)","78","false","0.0"),
            new Note("slideNote","68.73","(402,-275,0)","79","false","0.0"),
            new Note("slideNote","69.13","(575,-68,0)","80","false","0.0"),
            new Note("slideNote","69.63","(721,304,0)","81","false","0.0"),
            new Note("slideNote","71.59","(591,208,0)","82","false","0.0"),
            new Note("slideNote","72.04","(458,-67,0)","83","false","0.0"),
            new Note("slideNote","72.38","(239,-240,0)","84","false","0.0"),
            new Note("slideNote","72.95","(-110,-251,0)","85","false","0.0"),
            new Note("slideNote","73.39","(-404,-179,0)","86","false","0.0"),
            new Note("slideNote","73.97","(-684,271,0)","87","false","0.0"),
            new Note("normalNote","74.98","(247,200,0)","88","false","0.0"),
            new Note("longNote","74.99","(-516,0,0)","89","false","2.0"),
            new Note("normalNote","75.32","(246,199,0)","90","false","0.0"),
            new Note("normalNote","75.77","(719,-257,0)","91","false","0.0"),
            new Note("normalNote","76.14","(719,-279,0)","92","false","0.0"),
            new Note("slideNote","78.20","(502,311,0)","93","false","0.0"),
            new Note("slideNote","78.73","(518,10,0)","94","false","0.0"),
            new Note("slideNote","79.30","(519,-286,0)","95","false","0.0"),
            new Note("longNote","80.41","(-558,-3,0)","96","false","2.0"),
            new Note("normalNote","80.97","(657,248,0)","97","false","0.0"),
            new Note("normalNote","81.50","(250,-300,0)","98","false","0.0"),
            new Note("slideNote","84.73","(-529,296,0)","99","false","0.0"),
            new Note("slideNote","85.37","(-537,-6,0)","100","false","0.0"),
            new Note("slideNote","86.36","(-546,-288,0)","101","false","0.0"),
            new Note("longNote","89.49","(460,4,0)","102","false","2.0"),
            new Note("normalNote","91.09","(-529,264,0)","103","false","0.0"),
            new Note("normalNote","91.66","(-183,-116,0)","104","false","0.0"),
            new Note("normalNote","92.12","(-658,-256,0)","105","false","0.0"),
            new Note("normalNote","92.55","(-831,156,0)","106","false","0.0"),
            new Note("bigNormalNote","93.24","(498,0,0)","107","false","0.0"),
            new Note("smallNormalNote","94.56","(-254,311,0)","108","false","0.0"),
            new Note("smallNormalNote","95.05","(-767,263,0)","109","false","0.0"),
            new Note("smallNormalNote","95.55","(-745,-243,0)","110","false","0.0"),
            new Note("smallNormalNote","96.15","(-182,-246,0)","111","false","0.0"),
            new Note("slideNote","96.92","(193,-291,0)","112","false","0.0"),
            new Note("slideNote","97.26","(473,4,0)","113","false","0.0"),
            new Note("slideNote","97.68","(767,308,0)","114","false","0.0"),
            new Note("slideNote","99.84","(-806,309,0)","115","false","0.0"),
            new Note("slideNote","99.98","(-654,96,0)","116","false","0.0"),
            new Note("slideNote","100.45","(-490,-121,0)","117","false","0.0"),
            new Note("slideNote","100.94","(-214,-310,0)","118","false","0.0"),
            new Note("slideNote","102.11","(150,292,0)","119","false","0.0"),
            new Note("slideNote","102.47","(318,116,0)","120","false","0.0"),
            new Note("slideNote","102.77","(535,-72,0)","121","false","0.0"),
            new Note("slideNote","103.14","(772,-275,0)","122","false","0.0"),
            new Note("normalNote","104.73","(-502,4,0)","123","false","0.0"),
            new Note("longNote","105.62","(457,-3,0)","124","false","2.0"),
            new Note("normalNote","106.28","(-156,290,0)","125","false","0.0"),
            new Note("normalNote","106.86","(-457,-9,0)","126","false","0.0"),
            new Note("normalNote","107.57","(-762,-278,0)","127","false","0.0"),
            new Note("normalNote","109.15","(-710,295,0)","128","false","0.0"),
            new Note("normalNote","109.70","(-359,-280,0)","129","false","0.0"),
            new Note("normalNote","110.33","(-10,280,0)","130","false","0.0"),
            new Note("normalNote","110.99","(516,-256,0)","131","false","0.0"),
            new Note("normalNote","111.75","(788,285,0)","132","false","0.0"),
            new Note("longNote","112.84","(1,-1,0)","133","false","2.0"),
            new Note("smallNormalNote","115.23","(-521,236,0)","134","false","0.0"),
            new Note("smallNormalNote","115.48","(-535,231,0)","135","false","0.0"),
            new Note("smallNormalNote","115.84","(511,-230,0)","136","false","0.0"),
            new Note("smallNormalNote","116.11","(505,-225,0)","137","false","0.0"),
            new Note("slideNote","116.87","(-566,2,0)","138","false","0.0"),
            new Note("slideNote","117.28","(-1,-3,0)","139","false","0.0"),
            new Note("slideNote","117.86","(569,0,0)","140","false","0.0")
        };

        Note[] YouDidMeWrong1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] YouDidMeWrong1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] ADayatSea1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] ADayatSea1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] ADayatSea1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Muffin1Normal1 = new Note[]{
            new Note("smallNormalNote","1.00","(-454,186,0)","0","false","0.0"),
            new Note("smallNormalNote","1.36","(-454,186,0)","1","false","0.0"),
            new Note("normalNote","2.11","(-90,213,0)","2","false","0.0"),
            new Note("bigNormalNote","3.38","(574,136,0)","3","false","0.0"),
            new Note("slideNote","4.70","(-690,-69,0)","4","false","0.0"),
            new Note("slideNote","5.49","(-180,-92,0)","5","false","0.0"),
            new Note("slideNote","6.16","(499,-142,0)","6","false","0.0"),
            new Note("longNote","7.79","(-655,268,0)","7","false","2.0"),
            new Note("longNote","10.11","(49,329,0)","8","false","2.0"),
            new Note("longNote","12.44","(508,-62,0)","9","false","2.0"),
            new Note("longNote","14.81","(-537,-219,0)","10","false","5.0")
        };

        Note[] Muffin1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Muffin1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };


        song = new Song[]{
            new Song("0", "High", "JPB", 4, 6, 10, High1Normal4, High1Hard6, High1Death10),
            new Song("1", "The Light", "Tetrix Bass Feat. Veela", 1, 3, 5, TheLight1Normal1, TheLight1Hard3, TheLight1Death5),
            new Song("2", "Too Hot To Handle", "Fiko & BLUK", 1, 3, 5, TooHotToHandle1Normal1, TooHotToHandle1Hard3, TooHotToHandle1Death5),
            new Song("3", "You Did Me Wrong", "Cajama", 5, 3, 5, YouDidMeWrong1Normal5, YouDidMeWrong1Hard3, YouDidMeWrong1Death5),
            new Song("4", "A Day at Sea", "Everen Maxwell", 1, 3, 5, ADayatSea1Normal1, ADayatSea1Hard3, ADayatSea1Death5),
            new Song("5", "Muffin", "Raven & Kreyn", 1, 3, 5,Muffin1Normal1, Muffin1Hard3, Muffin1Death5)
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
