using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public string noteType { get; private set; }
    public string noteCreateTime { get; private set; }
    public string noteCreatePos { get; private set; }
    public string noteNum { get; private set; }
    public string isNoteSameTime { get; private set; }
    public string longNoteDuration { get; private set; }

    // 생성자
    public Note(string _noteType, string _noteCreateTime, string _noteCreatePos, string _noteNum, string _isNoteSameTime, string _longNoteDuration)
    {
        noteType = _noteType;
        noteCreateTime = _noteCreateTime;
        noteCreatePos = _noteCreatePos;
        noteNum = _noteNum;
        isNoteSameTime = _isNoteSameTime;
        longNoteDuration = _longNoteDuration;
    }


}
