/*

 #################
        V   ????
 #################=>????69
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[Serializable]
public class Mail : UnityEvent<Message> {
    public readonly string EventName;
    public readonly UnityEngine.Object [] Pupets;
    public readonly UnityEngine.Object[] Instruction;


    public Mail()
    {}
    public Mail(string en) {
        EventName = en;
    }


}
namespace KHNMU.Toolkit{ 
}



public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>, ISMInteractiv
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (aplicationQuit)
            {
                return null;
            }
            if (!_instance)
            {
                return CreateInstance();
            }
            return _instance;
        }
        private set { }
    }
    private static T CreateInstance()
    {
        var go = new GameObject($"_{Instance.GetType().ToString()}", new Type[1] { typeof(Singleton<T>) });
        _instance = go.GetComponent<T>();
        return go.GetComponent<T>();
    }
    private static T CreateInstance(T t)
    {
        if (t != null)
        {
            _instance = t;
            return _instance;
        }
        return CreateInstance();
        //GameObject go = CreateInstantGO("instant");

        //throw new NotImplementedException();
    }

    [SerializeField]
    public static List<Mail> EventJournal;

    //private static Dictionary<string, Mail> EventJournal = new Dictionary<string, Mail>();
    public static void MakeMark(string eventName, UnityAction<Message> listener) {
        Mail ml  = null;
        foreach (var item in EventJournal)
        {
            //if (EventJournal.TryGetValue(eventName, out ml))
            //{
            //}
            if (item.EventName== eventName)
            {
                ml.AddListener(listener);
                    print($"{listener.GetType()}");
            }
            else
            {
                ml = new Mail(eventName);
                ml.AddListener(listener);
                EventJournal.Add(ml);
            }
        }

    }
    public static void UnMark(string eventName, UnityAction<Message> listener) {
        if (_instance == null) return;
        Mail ml = null;
        foreach (var item in EventJournal)
        {
            if (item.EventName == eventName)
            {
                ml.RemoveListener(listener);
                print($"{listener.GetType()}");
            }
        }
    }
    public static void MakeMailForm(string eventName) {
        var ml = new Mail(eventName);
        EventJournal.Add(ml);
    }
        
    public static void takeMail(string eventName, Message m) {

        Mail ml = null;
        foreach (var item in EventJournal)
        {
            if (item.EventName == eventName)
            {
                ml?.Invoke(m);
                print($"[]");
            }
        }
    }
        //    if (EventJournal.TryGetValue(eventName, out ml))
                //ml.RemoveListener(listener);
        //    {
        //    }


    private static bool aplicationQuit =false;
    protected virtual void Awake () {
        if (_instance == null)
        { // Ёкземпл€р менеджера был найден
            //_instance = (T) this;
            _instance = CreateInstance((T)this);
            DontDestroyOnLoad((T)this);
            /*
             activeSceneChanged 
             sceneUnloaded      
             sceneLoaded        
             */
             EventJournal= new List<Mail>();
            SceneManager.activeSceneChanged +=  ActiveSceneChanged;
            SceneManager.sceneUnloaded +=       SceneUnloaded     ;
            SceneManager.sceneLoaded +=         SceneLoaded;
            return;
        }
        Destroy(gameObject); // ”дал€ем объект
    }

    protected void SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
       
    }

    protected virtual void SceneUnloaded(Scene arg0)
    {
        
    }

    protected virtual void ActiveSceneChanged(Scene arg0, Scene arg1)
    {
       
    }

    protected virtual void OnDestroy() {
        aplicationQuit = true; 
        
    }
}
/*
    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        
        if (arg0.name == "Cabinet")
        {
            SwitchPlayerState<MovingState>();
        }
        if (arg0.name == "MainMenu")
        {
            SwitchPlayerState<UIViewState>();
        }
    }

    private void sceneUnloaded(Scene arg0)
    {
        //print($"Unload scene:{arg0.name}");
    }

    private void SceneChanged(Scene arg0, Scene arg1)
    {
        
        
        print($"1 scene:{arg0.name},2 scene:{arg1.name}");
        print(arg0.name);
        print(arg1.name);
    }

 */
            //if (EventJournal.TryGetValue(eventName, out ml))
            //{
            //}

            //if (EventJournal.TryGetValue(eventName, out ml))
            //{
            //    ml.RemoveListener(listener);

public interface ISMInteractiv
{

    void ActiveSceneChanged             (Scene arg0, Scene arg1);
    void SceneUnloaded                  (Scene arg0);
    void SceneLoaded                    (Scene arg0, LoadSceneMode arg1);
}