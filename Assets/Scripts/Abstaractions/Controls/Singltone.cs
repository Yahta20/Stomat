using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singltone<T> where T : MonoBehaviour
{
    public class MessageClass<Adres, Mail>
    where Adres : MonoBehaviour
    where Mail : struct
    { };
    public struct Message { 
    }
    //public static Singltone<T> Instance{ get=> instance==null?new <T>(): instance;
    //                            set=>}
    
    private static Singltone<T> instance {
        get; set;
    }
    static List<Action> actionList;

    static List<Action<MessageClass<MonoBehaviour, Message>>> MsgList 
        = new List<Action<MessageClass<MonoBehaviour, Message>>>();
        //


}
