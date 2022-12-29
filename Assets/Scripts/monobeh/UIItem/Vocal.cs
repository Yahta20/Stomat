using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vocal : MonoBehaviour
{
    public RectTransform curentTransform;
    public RectTransform AnswerScroll;
    public RectTransform QuestionScroll;
    public RectTransform AnswerContent;
    public RectTransform QuestionContent;
    public Scrollbar     AnsverScrollBar;
    public Button        LAButton;
    public Button        ExitButton;

    bool ansverVisible = false;
    bool visiable = false;
    void Awake()
    {
        curentTransform.anchoredPosition = new Vector2(CanvasMaster.Instance.getSize().x, curentTransform.anchoredPosition.y);
        CleareContent(AnswerContent, Vector2.zero);
        CleareContent(QuestionContent, Vector2.zero);
    }
    private void OnDestroy()
    {
        UICustomES.Instance.onAskingBarShow -= Show;
        UICustomES.Instance.onAskingBarHide -= Hide;
        //LAButton.onClick.AddListener(Hide);
    }
    void Start()
    {
        UICustomES.Instance.onAskingBarShow += Show;
        UICustomES.Instance.onAskingBarHide += Hide;
        ExitButton.onClick.AddListener(Hide);
        //setSize();
        //UpdateText();
        //FillField();
    }
    public void Show()
    {
        UICustomES.Instance.ReleaseCursor();
        visiable = true;
        CleareContent(AnswerContent, Vector2.zero);
        CleareContent(QuestionContent, Vector2.zero);
        setSize();
        //UpdateText();
        //FillField();
        //UpdateText();
        //UpdateAnswer();
        curentTransform.anchoredPosition = new Vector2(0,  curentTransform.anchoredPosition.y);
        //Mathf.Lerp(curentTransform.anchoredPosition.x, 0, Time.deltaTime * 6), curentTransform.anchoredPosition.y);
    }
    public void Hide()
    {
        UICustomES.Instance.BlockCursor();
        visiable = false;
        //item.GetAnsvers(OrderAnswers.ToArray());
        curentTransform.anchoredPosition = new Vector2(CanvasMaster.Instance.getSize().x, curentTransform.anchoredPosition.y);
            //Mathf.Lerp(curentTransform.anchoredPosition.x, CanvasMaster.Instance.getSize().x, Time.deltaTime * 6), curentTransform.anchoredPosition.y);

    }
    private void setSize()
    {
        var ss = CanvasMaster.Instance.getSize();
        
        curentTransform.sizeDelta=   Vector2.zero  ;
        curentTransform.anchoredPosition = Vector2.zero;

        // AnswerScroll.sizeDelta = Vector2.zero;
        // AnswerScroll.anchoredPosition = Vector2.zero;



        //AnswerScrol.anchoredPosition = Vector2.zero;l   =     ;
        //QuestionScroll =     ;
        //AnswerContent  =     ;
        //QuestionContent=     ;
        //AnsverScrollBar=     ;
        //LAButton       =     ;
        //ExitButton     =     ;
    }



    void LateUpdate()
    {
        //if (visiable)
        //{
        //    curentTransform.anchoredPosition = new Vector2(Mathf.Lerp(curentTransform.anchoredPosition.x, 0, Time.deltaTime * 6), curentTransform.anchoredPosition.y);
        //}
        //else
        //{
        //    curentTransform.anchoredPosition = new Vector2(Mathf.Lerp(curentTransform.anchoredPosition.x, CanvasMaster.Instance.getSize().x, Time.deltaTime * 6), curentTransform.anchoredPosition.y);
        //}
    }
    private void CleareContent(Transform t, Vector2 startSize)
    {
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.transform.GetChild(i).gameObject);
        }
        t.GetComponent<RectTransform>().sizeDelta = startSize;

    }
}
/*
 * 
 * 
 * 
 * 
[SerializeField] private SliderFiller _progressSlider;  ConvertingSlider (Sliderfiller)

private BaseState _currentState;
private Queue<BaseState> _allStates;


private void Start()

{
_allStates = new Queue<BaseState>();
_allStates.Enqueue( item: new No0ilState(_player, _statusText));
_allStates.Enqueue( item: new HasOilState(_player, _statusText, _progressSlider));
_allStates.Enqueue( item: new FuelProductionState(_player, _statusText, _progressSlider));
_allStates .Enqueue( item: new NoMoneyState(_player, _statusText));
}
public void StaticFlow()

{
GoToNextState() ;
}
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */