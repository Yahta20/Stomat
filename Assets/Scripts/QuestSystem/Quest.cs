using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Creare Quest", order = 2)]
public class Quest : ScriptableObject
{
    public string Name;
    //public string InteractionGO;
    public QuestTask[] TaskList;
    public string Description;
    public QuestState State  { get; private set; } = QuestState.SLEEP;


    public QuestResult Grade()
    {
        QuestResult result = QuestResult.WELLDONE;
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
    }
}
