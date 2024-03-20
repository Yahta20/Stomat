using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KHNMU.BodyAnatomy;
using static Localizator;

[CreateAssetMenu(fileName = "Pacient", menuName = "ScriptableObjects/Quests/Creare Pacient", order = 1)]
public class PacientStat : ScriptableObject
{
    public int Sex; // 1-male 2-female
    public string PacientOrder;

    [Space]
    public GameObject prefab;
    [Space]
    
    public serviceText[] PasportData;
    public serviceText[] PatientComplaints;
    public serviceText[] Anamnez;
    public serviceText[] ADiseases;
    [Space]
    public serviceText Diagnos;

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
    private void Awake()
    {
        
    }

}
