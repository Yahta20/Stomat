using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singltone<T> where T : MonoBehaviour
{
    private static Singltone<T> instance 
    {
        get; set;
    }
    public T GenerateClass<T>(T param) {
        return param;
    }

    public static Singltone<T> Instance{ get=> Singltone<T>.instance;
        private set { instance = value; } }

    static      Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour,Message>>> MsgList 
        = new   Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>> MsgHistory
        = new   Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>>();



}
