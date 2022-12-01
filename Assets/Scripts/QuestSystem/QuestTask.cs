using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestTask", menuName = "ScriptableObjects/Creare QTask", order = 3)]
public class QuestTask : ScriptableObject
{
    public string Name;
    public string InteractionGO;
    public string[] MustCondition;
    public string[] PerfectCondition;
    public string Description;
    public QuestState State { get; private set; } = QuestState.SLEEP;
    public QuestResult Result { get; private set; } = QuestResult.UNDONE;

    public void setState(QuestState s)
    {
        State = s;
    }
}

public enum QuestState { 
    SLEEP,
    ACTIVE,
    DONE
}
public enum QuestResult
{
    UNDONE=0,
    DONE,
    WELLDONE
}

