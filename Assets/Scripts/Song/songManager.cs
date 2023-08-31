using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            new Note("longNote", "2.0", "(700,700,0)", "1", "false", "2.0"),
            new Note("longNote", "5.0", "(600,600,0)", "2", "false", "5.0")
        };

        Note[] FractureRay1Hard6 = new Note[]{
            new Note("normalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("longNote", "2.0", "(700,700,0)", "1", "false", "2.0"),
            new Note("normalNote", "5.0", "(600,600,0)", "2", "false", "")
        };

        Note[] FractureRay1Death10 = new Note[]{
            new Note("normalNote", "1.0", "(100,300,0)", "0", "false", ""),
            new Note("smallNormalNote", "2.0", "(300,300,0)", "1", "false", ""),
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
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "3.0", "(200,200,0)", "2", "false", ""),
            new Note("slideNote", "4.0", "(500,500,0)", "3", "false", "")
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


        song = new Song[]{
            new Song("0", "Fracture Ray", "Sakuzyo", 4, 6, 10, FractureRay1Normal4, FractureRay1Hard6, FractureRay1Death10),
            new Song("1", "Cytus II", "Cytus II", 1, 3, 5, CytusII1Normal1, CytusII1Hard3, CytusII1Death5)
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
}
