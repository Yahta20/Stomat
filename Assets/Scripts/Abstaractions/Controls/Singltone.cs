using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singlton: MonoBehaviour 
{
    public static Singlton instance 
    {
        get; private set;
    }
    

   

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
