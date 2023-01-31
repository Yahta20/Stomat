using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMaster : Singleton<QuestMaster>,IQuestStateSwitcher// MonoBehaviour
{
    public PacientStat      currentPacient {get; private set;}
    public PacientStat []   Pacients;



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
           // SwitchPlayerState<MovingState>();
        }
        if (arg0.name == "MainMenu")
        {
            //SwitchPlayerState<UIViewState>();
        }
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {
            currentPacient = ScriptableObject.CreateInstance<PacientStat>();//new PacientStat();
        }
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