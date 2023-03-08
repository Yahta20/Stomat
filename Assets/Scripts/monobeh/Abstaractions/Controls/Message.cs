

using System;
using System.Linq;
public struct Message 
{
    UnityEngine.MonoBehaviour _from;

    public Message(UnityEngine.MonoBehaviour f, string comand, object[] o ,Type[] t) {
        _from = f;
        Command = comand;
        parameters = o;
        parametersType = t;
    }

    public string Command{ get; private set; }

    
    public Type[] parametersType;
    public object[] parameters;

    public override string ToString() => $"({Command}, {parameters.Length})";
}

