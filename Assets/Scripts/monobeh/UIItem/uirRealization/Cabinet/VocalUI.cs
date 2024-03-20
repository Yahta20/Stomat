using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocalUI : MonoBehaviour
{
    
    public GameObject QButton;
    public GameObject TButton;
    public Button AnswerInteractive;
    public Button Exit;

    //ScrollView AnswerRect;
    //ScrollView QuestionRect;
    public ScrollRect AnsverContent;
    public ScrollRect QuestionContent;

    RectTransform mainRT;
    bool visiable=false;
    List<serviceText> questions  = new List<serviceText>();
    List<serviceText> answers    = new List<serviceText>();


    void Awake()
    {
        mainRT=GetComponent<RectTransform>();
        CompleatErase();
        AnswerInteractive.onClick.AddListener(
            () => {
                AnsverContent.gameObject.SetActive(
                AnsverContent.gameObject.active ? false : true
                    ) ;
            }
            );
    }

    private void OnEnable()
    {
        Show(false);
        ControlUI.Instance.onAskingBar += Show;
        SetSize();
        QuestMaster.Instance.onQuestTaskStart += Taskreaction;

    }

    private void Taskreaction(QuestTask obj)
    {
            //print(obj.InteractionGO);
        if (obj.InteractionGO == this.GetType().ToString()) { 
            
        }
    
    }

    private void SetSize()
    {
        var canvas = new Vector2(Screen.width, Screen.height);
        mainRT.sizeDelta = canvas * 0.93f;
        mainRT.anchoredPosition = Vector2.zero;

        Exit.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(mainRT.sizeDelta.y*0.07f, mainRT.sizeDelta.y * 0.07f);
        AnsverContent.GetComponent<RectTransform>().sizeDelta 
            = new Vector2(mainRT.sizeDelta.x*0.93f, mainRT.sizeDelta.y * 0.4f);
        QuestionContent.GetComponent<RectTransform>().sizeDelta
            = new Vector2(mainRT.sizeDelta.x * 0.93f, mainRT.sizeDelta.y * 0.4f);
        AnswerInteractive.GetComponent<RectTransform>().sizeDelta
            = new Vector2(mainRT.sizeDelta.x * 0.93f, mainRT.sizeDelta.y * 0.1f);

        AnsverContent.GetComponent<RectTransform>().anchoredPosition
            = new Vector2(0, mainRT.sizeDelta.y * 0.06f);
        QuestionContent.GetComponent<RectTransform>().anchoredPosition
            = new Vector2(0, -mainRT.sizeDelta.y * 0.06f);
        AnswerInteractive.GetComponent<RectTransform>().anchoredPosition
            = Vector2.zero;
        //QuestionContent;

    }

   
    private void OnDisable()
    {
        ControlUI.Instance.onAskingBar -= Show;
    }

    void Update()
    {
        if (visiable)
        {
            mainRT.anchoredPosition = new Vector2(Mathf.Lerp(mainRT.anchoredPosition.x, 0, Time.deltaTime * 3), 0);
        }
        else
        {
            mainRT.anchoredPosition = new Vector2(Mathf.Lerp(mainRT.anchoredPosition.x, Screen.width, Time.deltaTime * 3), 0);
        }
    }

    public void RecordAnswer(serviceText record) { 
        answers.Add(record);
        var btn = Instantiate(TButton, AnsverContent.transform);
        //var qb = btn.GetComponent<questButton>();
        btn.GetComponent<RectTransform>().sizeDelta =
            new Vector2(0, mainRT.sizeDelta.y * 0.1f);
        //qb.SetButton(this, st[i], (int)(mainRT.sizeDelta.y * 0.9f));
        AnsverContent.content.sizeDelta += new Vector2(0, mainRT.sizeDelta.y * 0.1f + 8);
    }

    public void FillQuestion(serviceText[] st) {
        QuestionContent.content.sizeDelta = Vector2.zero;
        for (int i = 0; i < st.Length; i++)
        {
            var btn = Instantiate(QButton,QuestionContent.transform);
            var qb = btn.GetComponent<questButton>();
            btn.GetComponent<RectTransform>().sizeDelta =
                new Vector2(0, mainRT.sizeDelta.y * 0.1f);
            qb.SetButton(this,st[i],(int)(mainRT.sizeDelta.y * 0.9f));
            QuestionContent.content.sizeDelta += new Vector2(0, mainRT.sizeDelta.y * 0.1f+8);
        }
    
    }

    public void Show(bool obj)
    {
        visiable = obj;
        SetSize();
    }
    public void CompleatErase() {
        CleareContent(QuestionContent.content);
        CleareContent(AnsverContent.content);
    }    
    void CleareContent(Transform t) {
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.transform.GetChild(i).gameObject);
        }
        t.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
    }

}