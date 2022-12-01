using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocalUI : PageUI
{
    public GameObject AskingPrefab;
    
    public Button HideB;
    public Button AnswerInteractive;

    public ScrollRect AnswerRect;
    public ScrollRect QuestionRect;



    protected override void setLang(SystemLanguage lang)
    {
       
    }

    protected override void setSize(Vector2 screen)
    {
    
    }

    void CleareContent(ScrollRect sr) {
        for (int i = 0; i < sr.content.childCount; i++)
        {
            Destroy(sr.content.transform.GetChild(i).gameObject);
        }
        sr.content.sizeDelta = Vector2.zero;
    }

    void Awake()
    {
        CleareContent(AnswerRect);
        CleareContent(QuestionRect);
    }
    private void OnDisable()
    {
        UICustomES.Instance.onAskingBarShow -= Show;
        UICustomES.Instance.onAskingBarHide -= Hide;
        //LAButton.onClick.AddListener(Hide);
    }
    void Start()
    {
        base.Start();
        UICustomES.Instance.onAskingBarShow += Show;
        UICustomES.Instance.onAskingBarHide += Hide;
        Hide();
        HideB.onClick.AddListener(Hide);

        //setSize();
        //UpdateText();
        //FillField();
    }

    public void Show()
    {
        currentTransform.anchoredPosition = new Vector2(0, currentTransform.anchoredPosition.y);
       
    }

    public void Hide()
    {
        currentTransform.anchoredPosition = new Vector2(UICustomES.Instance.screenResolution.x, currentTransform.anchoredPosition.y);
    }
}