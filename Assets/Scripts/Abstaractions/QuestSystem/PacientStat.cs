using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KHNMU.BodyAnatomy;
[CreateAssetMenu(fileName = "Pacient", menuName = "ScriptableObjects/Creare Pacient", order = 1)]
public class PacientStat : ScriptableObject
{
    public string Sex;
    public string PacientOrder;

    public string[] PasportData;
    public string[] PatientComplaints;
    public string[] Anamnez;
    public string[] ADiseases;
    [Space]
    public string Diagnos;


    public Faucibus PacientJaw;

    public Quest[] questList;

    public QuestResult Grade() {
        QuestResult result = QuestResult.WELLDONE;
        foreach (Quest item in questList)
        {
            if (item.Grade() < result)
            {
                result = item.Grade();
            }
        }

        return result;
    }

    public Quest getCurentQuest() {
        foreach (var item in questList)
        {
            if (item.State==QuestState.ACTIVE)
            {
                return item;
            }
        }
        questList[0].setState(QuestState.ACTIVE);
        return questList[0];
    }

    public QuestTask getCurentTask()
    {
        var q = getCurentQuest();
        foreach (var item in q.TaskList)
        {
            if (item.State == QuestState.ACTIVE)
            {
                return item;
            }
        }
        q.TaskList[0].setState(QuestState.ACTIVE);
        return q.TaskList[0];
    }
}
