using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMaster : Singlton<QuestMaster>
{
 
    public PacientStat currentPacient {get; private set;}
    public PacientStat[] Pacients;

    public event Action<QuestTask>  onQuestTaskStart;
    public void TaskStart(QuestTask task)
    {
        onQuestTaskStart?.Invoke(task);
    }

    public event Action<Quest>      onQuestStart;
    public void QuestStart(Quest quest) {
        onQuestStart?.Invoke(quest);    
    }


    public event Action<QuestTask>  onQuestTaskComplete;
    public event Action<Quest>      onQuestComplete;

    Queue<Quest> currentQueue;
    Dictionary<string, Quest> QuestsLib = new  Dictionary<string, Quest>();




    //public event Action onComplete;
    /*
    public void QTaskComplete() {
        if (onQuestTaskComplete !=null)
        {
            onQuestTaskComplete();
        }
    }
    public void QuestComplete() {
        if (onQuestComplete != null)
        {
            onQuestComplete();
        }
    }
     */
    public override void Awake()
    {
        base.Awake();    
    }
    private void OnEnable()
    {
        //print(ScenaController.Instance);
        //print(ScenaController.Instance.currentScene);
        SceneManager.sceneLoaded += SceneLodet;


        
    }

    private void SceneLodet(Scene arg0, LoadSceneMode arg1)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentPacient = ScriptableObject.CreateInstance<PacientStat>();//new PacientStat();
        }
        if (arg0.name == "Cabinet")
        {
            if (currentPacient != null)
            {
                CreatingQuest();
            }
        }
    }

    public void SetPatient(int i) {
        currentPacient = Pacients[i];
    }
    private void CreatingQuest()
    {
        foreach (var item in currentPacient.questList)
        {
            QuestsLib.Add(item.id,item);
        }
        QuestsLib[currentPacient.questList[0].id].ActivateQuest(); //setState(QuestState.ACTIVE);

        

        /*
        currentQueue.Enqueue(item);
        
        print(currentQueue.Count);
         */
    }
    public  void CheckAnsver(string board,string[] answers)
    {


    }

    
}
