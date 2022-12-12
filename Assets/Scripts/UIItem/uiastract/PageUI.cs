using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


[RequireComponent(typeof(Image))]
public abstract class PageUI : MonoBehaviour
{
    protected Image         currentFont;
    protected RectTransform currentTransform;
    public void OnDisable()
    {
        UICustomES.Instance.onChangeScreeSize -= setSize;
        Localizator.Instance.OnChangetLang -= setLang;
    }

    public void Start()
    {

        currentFont     =GetComponent<Image>();
        currentTransform=GetComponent<RectTransform>();
        UICustomES.Instance.onChangeScreeSize += setSize;
        Localizator.Instance.OnChangetLang += setLang;
        setSize(new Vector2(UICustomES.Instance.Resolution.width, UICustomES.Instance.Resolution.height));
        setLang(Localizator.Instance.currLang);
    }
    protected abstract void setSize(Vector2 screen);
    protected abstract void setLang(SystemLanguage lang);
}

    //public List<RectTransform> cildItems;

    //protected List<UIBehaviour> cildItems;
    //protected List<Action> cildAction;

    
    
    







