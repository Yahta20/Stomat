using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocalUI : PageUI
{
    public GameObject AskingPrefab;

    public PlaningUI Interier;

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
        _Transform.sizeDelta = screen*0.88f;
        _Transform.anchoredPosition = Vector2.zero;
        _Transform.anchorMin = new Vector2(0.5f, 0.5f);
        _Transform.anchorMax = new Vector2(0.5f, 0.5f);

        var HideBRT = HideB.GetComponent<RectTransform>();

            HideBRT.sizeDelta = screen * 0.09f;
            HideBRT.anchorMin   = new Vector2(1f, 0f);
            HideBRT.anchorMax   = new Vector2(1f, 0f);
            HideBRT.pivot       = new Vector2(0,0f);
            HideBRT.anchoredPosition = Vector2.zero;

        //setSize(screen, _Interier);
    }
    protected void setSize(Vector2 screen, PlaningUI obj)
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
        UICustomES.Instance.ReleaseCursor();
        _Transform.anchoredPosition = new Vector2(0, _Transform.anchoredPosition.y);
       
    }

    public void Hide()
    {
        UICustomES.Instance.BlockCursor();
        _Transform.anchoredPosition = new Vector2(UICustomES.Instance.screenResolution.x, _Transform.anchoredPosition.y);
    }
}