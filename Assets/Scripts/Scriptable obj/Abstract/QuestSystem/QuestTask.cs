using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Localizator;

[CreateAssetMenu(fileName = "QuestTask", menuName = "ScriptableObjects/Quests/Creare QTask", order = 3)]
public class QuestTask : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; }
    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    public serviceText Name;
    public string InteractionGO;
    
    public string[] MustCondition;
    public string[] PerfectCondition;
    public serviceText Description;

    [Space]
    public serviceText[] Data;

    public QuestState State { get; private set; } = QuestState.SLEEP;
    public QuestResult Result { get; private set; } = QuestResult.UNDONE;

    public void setState(QuestState s)
    {
        State = s;
    }
    public void ActivateTask()
    {
        if (State == QuestState.SLEEP)
        {
            State = QuestState.ACTIVE;
            QuestMaster.Instance.TaskStart(this);
        }
    }
    public void FinishTask()
    {
        if (State == QuestState.ACTIVE)
        {
            State = QuestState.DONE;
        }

    }
    private void Awake()
    {
        Name.fillText();
        Description.fillText();
        foreach (var item in Data)
        {
            item.fillText();
        }
        //foreach (var item in Data)
        //{
        //    item.fillText();
        //}

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

