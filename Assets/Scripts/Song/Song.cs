using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song
{
    public string id { get; private set; }
    public string songName { get; private set; }
    public string songComposer { get; private set; }
    public string songFileURL { get; private set; }
    public string songImageFileURL { get; private set; }
    public int songNormalDifficulty { get; private set; }
    public int songHardDifficulty { get; private set; }
    public int songDeathDifficulty { get; private set; }
    public string songNormalDifficultyURL { get; private set; }
    public string songHardDifficultyURL { get; private set; }
    public string songDeathDifficultyURL { get; private set; }
    public Note[] chartNormal { get; private set; }
    public Note[] chartHard { get; private set; }
    public Note[] chartDeath { get; private set; }

    public Song(string _id, string _songName, string _songComposer, int _songNormalDifficulty, int _songHardDifficulty, int _songDeathDifficulty, Note[] _chartNormal, Note[] _chartHard, Note[] _chartDeath)
    {
        id = _id;
        songName = _songName;
        songComposer = _songComposer;
        songFileURL = "Audio/PlayableSong/" + songName;
        songImageFileURL = "Play/SongArt/" + songName + " Song Art";
        songNormalDifficulty = _songNormalDifficulty;
        songHardDifficulty = _songHardDifficulty;
        songDeathDifficulty = _songDeathDifficulty;
        songNormalDifficultyURL = "Play/UI/Normal" + _songNormalDifficulty;
        songHardDifficultyURL = "Play/UI/Hard" + _songHardDifficulty;
        songDeathDifficultyURL = "Play/UI/Death" + _songDeathDifficulty;
        chartNormal = _chartNormal;
        chartHard = _chartHard;
        chartDeath = _chartDeath;
    }

    
}
