using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singlton
    //<T>
    : MonoBehaviour //where T:MonoBehaviour
{


    public static Singlton Instance
    {
        get {
            if (instance==null)
            {
                var Sgo = new GameObject($"{typeof(Singlton).ToString()}/");
                Sgo.AddComponent<Singlton>();
                instance = Sgo.GetComponent<Singlton>();
            }
            return instance; } 
        private set { instance = value; }
    }

    protected static Singlton instance;

    
    static      Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour,Message>>> MsgList 
        = new   Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>> MsgHistory
        = new   Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>>();

   protected void Awake() {
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
            DontDestroyOnLoad(this);
            
            return;
        }
        Destroy(gameObject); // Удаляем объект

    }
}
