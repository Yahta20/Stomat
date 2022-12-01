using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMaster : MonoBehaviour
{
    public static QuestMaster Instance;

    public PacientStat currentPacient {get; private set;}
    public PacientStat[] Pacients;

    public event Action onQuestTaskComplete;
    public event Action onQuestComplete;
    //public event Action onComplete;
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
    void Awake()
    {
         // «адаем ссылку на экземпл€р объекта
        if (Instance == null)
        { // Ёкземпл€р менеджера был найден
            Instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (Instance != this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
        DontDestroyOnLoad(this);
    }
    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {
            currentPacient = ScriptableObject.CreateInstance<PacientStat>();//new PacientStat();
        }
        //print(ScenaController.Instance);
        //print(ScenaController.Instance.currentScene);
        if (ScenaController.Instance.currentScene.name == "Cabinet")
        {
            if (currentPacient!=null)
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
        
    }
    public  void CheckAnsver(string board,string[] answers)
    {


    }

}
