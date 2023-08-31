using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Rank
{
    public string rank;
    public string nickname;
    public string score;
    public string progress;
}

[Serializable]
public class Ranks
{
    public Rank[] ranks;
}

