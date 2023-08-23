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
        Note longNote = new Note("longNote", "1.0", "(300,300,0)", "0", "false", "1.0");
        Note normalNote = new Note("normalNote", "1.0", "(300,300,0)", "0", "false", "1.0");
        Note smallNormalNote = new Note("smallNormalNote", "1.0", "(300,300,0)", "0", "false", "1.0");

        Note[] normalChart = new Note[] { longNote };
        Note[] hardChart = new Note[] { normalNote };
        Note[] deathChart = new Note[] { smallNormalNote };

        song = new Song[]{new Song("FractureRay1", "Fracture Ray", 4, 6, 10, normalChart, hardChart, deathChart)};

    }
}
