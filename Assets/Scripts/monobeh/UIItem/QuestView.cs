using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestView : MonoBehaviour
{

    public Button ExitButton;
    RectTransform currentTransform;
    
    bool visual;

    // Start is called before the first frame update
    void Start()
    {
        currentTransform = GetComponent<RectTransform>();
        visual = false;
        ExitButton.onClick.AddListener(Hide);

    }
    private void OnEnable()
    {
        UICustomES.Instance.onQuestBarShow += Show;
        UICustomES.Instance.onQuestBarHide += Hide;
    }

    private void Show()
    {
        visual = true;
        UICustomES.Instance.ReleaseCursor();

    }
    public void Hide()
    {

        visual = false;
        UICustomES.Instance.BlockCursor();
    }
    

    void LateUpdate()
    {
        updateDraw();
    }
    
    private void updateDraw()
    {
        currentTransform.sizeDelta = CanvasMaster.Instance.getSize()*0.93f;
        ExitButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(CanvasMaster.Instance.getSize().x*0.07f, CanvasMaster.Instance.getSize().x*0.07f);
        if (visual)
        {
            currentTransform.anchoredPosition =
                new Vector2(Mathf.Lerp(currentTransform.anchoredPosition.x, 0, Time.deltaTime * 6),
               0);
        }
        else
        {
            currentTransform.anchoredPosition = new Vector2(
                Mathf.Lerp(currentTransform.anchoredPosition.x, CanvasMaster.Instance.getSize().x*2, Time.deltaTime * 6),
                0);
        }
    }
}

