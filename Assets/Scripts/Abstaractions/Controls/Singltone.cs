using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singltone<T> where T : MonoBehaviour
{
    public class MessageClass<FAdress,TAdress,Mail>
    where FAdress : MonoBehaviour
    where TAdress : MonoBehaviour
    where Mail : struct
    { };
    public struct Message { 
    }
    private static Singltone<T> instance {
        get; set;
    }


    static      Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour,Message>>> MsgList 
        = new   Queue<Action<MessageClass<MonoBehaviour, MonoBehaviour, Message>>>();

    static      Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>> MsgHistory
        = new   Stack<MessageClass<MonoBehaviour, MonoBehaviour,Message>>();









}

    //public static Singltone<T> Instance{ get=> { if (instance == null) 
    //                                                new Singltone<T> ();
    //                                                else instance; } 
    //                            set=>}
    
    //static      List<MonoBehaviour> wer ;
    //
    //