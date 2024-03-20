using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestBoardUI : MonoBehaviour
{
    public GameObject Quest;
    [Space]
    public Text             MainLabel;
    public Text             Description;

    public ScrollRect       questlist;
    public Button           exit;
    public RectTransform    Mainpanel;
    private bool visiable;




    void Start()
    {
        Mainpanel = GetComponent<RectTransform>(); 
        SetSize();



    }


    public void changeView() { 
        visiable = !visiable;
        SetSize();
    }
    private void SetSize()
    {
        var canvas = new Vector2(Screen.width, Screen.height);

            var e = canvas*0.93f;
        Mainpanel.sizeDelta = e;
        MainLabel.rectTransform.sizeDelta = new Vector2(e.x,e.y*0.2f); 
        Description.rectTransform.sizeDelta = new Vector2(e.x*0.5f, e.y * 0.8f);

        questlist.GetComponent<RectTransform>().sizeDelta = new Vector2(e.x * 0.5f, e.y * 0.8f);
        //exit.GetComponent<RectTransform>().sizeDelta = new Vector2(e.x * 0.05f, e.x * 0.05f);
        //exit.onClick.RemoveAllListeners();
        //exit.onClick.AddListener(()=>changeView());

    }


    // Update is called once per frame
    void Update()
    {
        if (visiable)
        {
            Mainpanel.anchoredPosition = new Vector2(Mathf.Lerp(Mainpanel.anchoredPosition.x, 0, Time.deltaTime * 3), 0);
        }
        else
        {
            Mainpanel.anchoredPosition = new Vector2(Mathf.Lerp(Mainpanel.anchoredPosition.x, Screen.width, Time.deltaTime * 3), 0);
        }
    }
}
