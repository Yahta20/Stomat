using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Localizator;

public class questButton : MonoBehaviour
{
    //public VocalUI master;
    public Button curbutton;
    public Text curtext;
    serviceText content;
    


    private void Start()
    {
        Localizator.Instance.OnChangetLang += changinlang;
    }

    private void changinlang()
    {
        curtext.text = content.uiTextD[Localizator.Instance.CurrLang];
    }

    public void SetButton(VocalUI a,serviceText st,int fontsize) {
        content = st;
        curtext.fontSize = fontsize;
        changinlang();
        curbutton.onClick.AddListener(() => {
            a.RecordAnswer(st);
            Destroy(gameObject);
        });

    } 
    

}
