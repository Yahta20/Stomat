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
             */
            //if (_instance == null) {
            //    return CreateInstance();
            //}

            return _instance;
        }
        private set { }
    }

    private static T CreateInstance()
    {
        var go  = new GameObject($"_{Instance.GetType().ToString()}", new Type[1] { typeof(Singleton<T>)});
        _instance = go.GetComponent<T>(); 
        return go.GetComponent<T>();
        //return 
       //Instance = 
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

    private static GameObject CreateInstantGO(string v)
    {
        //if ("instant" == v) {
        //    return new GameObject(Instance.GetType().ToString());
        //}
        return new GameObject($"{v}_{Instance.GetType().ToString()}");
        //return GameObject(Instance.GetType().ToString);


    }

    static      Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour,Message>>> MsgList 
        = new   Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>> MsgHistory
        = new   Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>>();
    private static bool aplicationQuit =false;

    protected virtual void Awake() {
        if (_instance == null)
        { // Ёкземпл€р менеджера был найден
            //_instance = (T) this;
            _instance = CreateInstance((T)this);


            DontDestroyOnLoad((T)this);
            
            return;
        }
        
            Destroy(gameObject); // ”дал€ем объект


    }
    protected virtual void OnDestroy() {
        aplicationQuit = true;    
    }
}
