using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Localizator;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quests/Creare Quest", order = 2)]
public class Quest : ScriptableObject
{

    [field:SerializeField] public string id { get; private set; }
    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    public serviceText Name;
    //public string InteractionGO;
    public QuestTask[] TaskList;
    public serviceText Description;

    
    public QuestState State { get; private set; } = QuestState.SLEEP;
    public QuestResult Grade()
    {
        QuestResult result = QuestResult.UNDONE;
        foreach (QuestTask item in TaskList)
        {
            if (item.Result < result)
            {
                result = item.Result;
            }
        }

        return result;
    }
    public void setState(QuestState s) {
        State = s;
        switch (State)
        {
            case QuestState.SLEEP:
                break;
            case QuestState.ACTIVE:
                TaskList[1].setState(QuestState.ACTIVE);
                break;
            case QuestState.DONE:
                
                break;
        }
    }
    public void ActivateQuest() {
        if (State== QuestState.SLEEP)
        {
            State = QuestState.ACTIVE;
            //QuestMaster.Instance.onQuestStart();
            TaskList[0].ActivateTask();

        }
    }
    public void FinishQuest()
    {
        if (State == QuestState.ACTIVE)
        {
            State = QuestState.DONE;
        }
    }





}
