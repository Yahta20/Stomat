using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlUI : Singlton<ControlUI>
{
    
    
    public event Action<string,bool> onInfoTextShow;
    public event Action<string,int> onStatusTextShow;
    public void InfoTextShowT(string name,bool state)
    {
            onInfoTextShow?.Invoke(name,state);
    }
    public void StatusTextShowT(string name, int duration) {
        onStatusTextShow?.Invoke(name,duration);
    }


    


    public event Action<bool> onMedicalCard;
    public event Action<bool> onAskingBar;
    public event Action<bool> onQuestBar;
    public event Action<bool> onResult;
    public void MedCard(bool state)
    {
        onMedicalCard?.Invoke(state);
    }
    public void Vocal(bool state)
    {
        onAskingBar?.Invoke(state);
    }
    public void Questbar(bool state)
    {
        onQuestBar?.Invoke(state);
    }
    public void Result(bool state)
    {
        onResult?.Invoke(state);
    }

    void Start()
    {
        
    }

    void Update()
    {
           
    }



}
