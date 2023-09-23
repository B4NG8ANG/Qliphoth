using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Record
{
    public string songID;
    public int score;
    public string progress;
}

[Serializable]
public class Records
{
    public Record[] records;
}
