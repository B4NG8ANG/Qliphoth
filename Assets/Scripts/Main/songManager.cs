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
        
        Note[] normalChart = new Note[] {new Note("longNote", "1.0", "(300,300,0)", "0", "false", "1.0")};
        Note[] hardChart = new Note[] {new Note("normalNote", "1.0", "(300,300,0)", "0", "false", "1.0")};
        Note[] deathChart = new Note[] {new Note("smallNormalNote", "1.0", "(300,300,0)", "0", "false", "1.0")};

        Note[] cytusNormal = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        song = new Song[]{
            new Song("FractureRay1", "Fracture Ray", 4, 6, 10, normalChart, hardChart, deathChart),
            new Song("CytusII1", "Cytus II", 4, 6, 10, cytusNormal, hardChart, deathChart)};
    }

    // public string getSongbyId(){}
}
