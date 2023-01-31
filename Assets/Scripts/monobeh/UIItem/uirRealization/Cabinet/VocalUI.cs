using KHNMU.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocalUI : PageUI
{
    public GameObject AnswerPrefab;
    public GameObject QuestionPrefab;
    [Space]
    public Button HideB;
    public Button AnswerInteractive;
    
    public ScrollRect AnswerRect;
    public ScrollRect QuestionRect;

    private void OnEnable()
    {
        base.OnEnable();
        UICustomES.Instance.onAskingBarShow += Show;
        UICustomES.Instance.onAskingBarHide += Hide;
    }

    protected override void setLang(SystemLanguage lang)
    {
       
    }

    protected override void setSize(Vector2 screen)
    {
        base.setSize(screen);
    }

    void Awake()
    {
        PrepearNewCase();
    }

    private void PrepearNewCase()
    {
        ToolKit.EraseChildObject(AnswerRect.content);
        ToolKit.EraseChildObject(QuestionRect.content);
    }
        

    private void OnDisable()
    {
        base.OnDisable();
        UICustomES.Instance.onAskingBarShow -= Show;
        UICustomES.Instance.onAskingBarHide -= Hide;
        //LAButton.onClick.AddListener(Hide);
    }
    void Start()
    {
        _Transform.anchoredPosition = new Vector2(UICustomES.Instance.screenResolution.x, _Transform.anchoredPosition.y);
        HideB.onClick.AddListener(Hide);
        
    }
      



    public void Show()
    {
        PlayControl.Instance.SwitchPlayerState<UIViewState>();
        _Transform.anchoredPosition = new Vector2(0, _Transform.anchoredPosition.y);
    }

       

    public void Hide()
    {
        PlayControl.Instance.SwitchPlayerState<MovingState>();
        _Transform.anchoredPosition = new Vector2(UICustomES.Instance.screenResolution.x, _Transform.anchoredPosition.y);
    }
}
     