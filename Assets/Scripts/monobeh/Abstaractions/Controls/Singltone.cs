using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public abstract class Singlton<T>: MonoBehaviour where T : Singlton<T>
{


    public static T Instance
    {
        get {
            if (instance == null)
            {

                instance = FindObjectOfType<T>();

                if (instance == null)
                { 
                    var Sgo = new GameObject($"{typeof(Singlton<T>).ToString()}/");
                    instance = Sgo.AddComponent<T>();
                
                }

                   // Debug.LogError(typeof(T).ToString() + " is missing.");
            }
            return instance; }
        private set { instance = value; }
    }

    private static T instance;



   public virtual void Awake() {
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this as T; // ������ ������ �� ��������� �������
            DontDestroyOnLoad(this);
            //return;
        }
        else { 
        Destroy(gameObject); // ������� ������
        }
   }
    public virtual void OnApplicationQuit()
    {

        if (instance != null)
        {
            //print($"{instance.name}?");
            Destroy(gameObject);
        }
    }





}
