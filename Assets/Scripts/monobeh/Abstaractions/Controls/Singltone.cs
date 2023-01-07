using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private  static T _instance;
    //private static object _lock = new object();
    public static T Instance
    {
        get
        {
            //if (aplicationQuit)
            //{
            //    return null;
            //}
            //lock (_lock)
            //{
            //    {
            //        //return 
            //        _instance=new GameObject(typeof(T).ToString()).AddComponent<T>();
            //    }
            //}
            /*
            if (_instance == null) { 
            }
             */
            return _instance;
        }
        private set { }
    }


    static      Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour,Message>>> MsgList 
        = new   Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>> MsgHistory
        = new   Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>>();
    private static bool aplicationQuit =false;

    protected virtual void Awake() {
        if (_instance == null)
        { // Ёкземпл€р менеджера был найден
            _instance = (T) this;
            DontDestroyOnLoad((T)this);
            
            return;
        }
        
            Destroy(gameObject); // ”дал€ем объект


    }
    protected virtual void OnDestroy() {
        aplicationQuit = true;    
    }
}
