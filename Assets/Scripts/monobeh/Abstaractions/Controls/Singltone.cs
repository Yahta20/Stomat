using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Singlton<T>: MonoBehaviour where T : Singlton<T>
{


    public static T Instance
    {
        get {
            if (instance == null)
            {
                Debug.LogError(typeof(T).ToString() + " is missing.");
                //var Sgo = new GameObject($"{typeof(Singlton<T>).ToString()}/");
                //Sgo.AddComponent<Singlton<T>>();
                //instance = Sgo.GetComponent<Singlton<T>>();
            }
            return instance; }
        private set { instance = value; }
    }

    protected static T instance;

    static Dictionary<string, UnityAction> Skills = new Dictionary<string, UnityAction>();
    //static Dictionary<string,UnityAction<object>> Skills = new Dictionary<string, UnityAction<object>>();
        //= new Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour,Message>>> MsgList 
        = new   Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>> MsgHistory
        = new   Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>>();

   protected virtual void Awake() {
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this as T; // Задаем ссылку на экземпляр объекта
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(gameObject); // Удаляем объект
            
   }


    static void addAction(string name,object obj) { 
        
    }

    protected virtual void OnEnable()
    {
        


    }

}
