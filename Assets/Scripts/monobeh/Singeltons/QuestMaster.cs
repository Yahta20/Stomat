using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMaster : Singleton<QuestMaster>,IQuestStateSwitcher// MonoBehaviour
{
    public PacientStat      currentPacient {get; private set;}
    public PacientStat []   Pacients;

    public List<SimpleQuestState> CurrentPacientQuest       =new List<SimpleQuestState>();
    public List<QuestTrasition> currentPacientQTransition   =new List<QuestTrasition>();

    public event Action OnQuestTaskComplete;
    public event Action OnQuestComplete;
    //public event Action onComplete;
    public void QTaskComplete() {
            OnQuestTaskComplete?.Invoke();
    }
    public void QuestComplete() {
            OnQuestComplete?.Invoke();
    }


    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += sceneLoaded;
    }

    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "Cabinet")
        {
            BuildQuestGrapf();
        }
        if (arg0.name == "MainMenu")
        {
            currentPacient = ScriptableObject.CreateInstance<PacientStat>();
        }
    }

    private void BuildQuestGrapf()
    {
        foreach (var item in currentPacient.questList)
        {
            CurrentPacientQuest.Add(
                new SimpleQuestState(this,  item)
                );
        }
        for (int i = 0; i <= CurrentPacientQuest.Count; i++)
        {
            currentPacientQTransition.Add(
                new QuestTrasition(CurrentPacientQuest[i], CurrentPacientQuest[i + 1],this)
                );
        }
       // throw new NotImplementedException();
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {
            currentPacient = ScriptableObject.CreateInstance<PacientStat>();//new PacientStat();
        }
        //print($"quest enable");
    }

    public void SetPatient(int i) {
        currentPacient = Pacients[i];
    }
    private void CreatingQuest()
    {
    }
        
    public  void CheckAnsver(string board,string[] answers)
    {
    }

    public void SwitchQuestrState<T>() where T : QuestBaseState
    {
       
    }
}