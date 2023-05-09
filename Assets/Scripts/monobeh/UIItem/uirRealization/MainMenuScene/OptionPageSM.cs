using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPageSM : PageUI
{
    /**/
    public Button   PrevMenu;
    public Button   LangChange;
    public Text     CurrenLang;


    Text PrevButText;
    Text LangChangeText;
    protected override void setLang(SystemLanguage lang)
    {
    }

    protected override void setSize(Vector2 screen)
    {
       // PrevButText.text = Localizator.Instance.GetLocalText(PrevMenu.gameObject.name);
       // LangChangeText.text = Localizator.Instance.GetLocalText(LangChange.gameObject.name);
       // CurrenLang.text = Localizator.Instance.GetLocalText(CurrenLang.gameObject.name);
       // base.setSize(screen);
        /*
        _Font.color = new Color(0, 0, 0, 0);
        _Transform.sizeDelta = screen;
        _Transform.anchoredPosition = Vector2.zero;
        _Transform.anchorMin = new Vector2(0.5f, 0.5f);
        _Transform.anchorMax = new Vector2(0.5f, 0.5f);
        //prev button
        var PrevMenuRT = PrevMenu.GetComponent<RectTransform>();

        PrevMenuRT.anchorMin = new Vector2(0, 1);
        PrevMenuRT.anchorMax = new Vector2(0, 1);
        PrevMenuRT.pivot = new Vector2(0, 1);
        PrevMenuRT.sizeDelta = new Vector2(_Transform.sizeDelta.x / 10, _Transform.sizeDelta.y / 16);
        PrevMenuRT.anchoredPosition = new Vector2(0, 0);
        //lang button button
        var LangChangeRT = LangChange.GetComponent<RectTransform>();

        LangChangeRT.anchorMin = new Vector2(0.5f, 0.5f);
        LangChangeRT.anchorMax = new Vector2(0.5f, 0.5f);
        LangChangeRT.pivot = new Vector2(1, 0.5f);
        LangChangeRT.sizeDelta = new Vector2(_Transform.sizeDelta.x / 10, _Transform.sizeDelta.y / 16);
        LangChangeRT.anchoredPosition = new Vector2(-_Transform.sizeDelta.x / 10, 0);
        //curent lang button 
        var CurrenLangRT = CurrenLang.GetComponent<RectTransform>();

        CurrenLangRT.anchorMin = new Vector2(0.5f, 0.5f);
        CurrenLangRT.anchorMax = new Vector2(0.5f, 0.5f);
        CurrenLangRT.pivot = new Vector2(0, 0.5f);
        CurrenLangRT.sizeDelta = new Vector2(_Transform.sizeDelta.x / 10, _Transform.sizeDelta.y / 16);
        CurrenLangRT.anchoredPosition = new Vector2(_Transform.sizeDelta.x / 10, 0);


        PrevButText     .resizeTextForBestFit = true;
        LangChangeText  .resizeTextForBestFit = true;
        CurrenLang      .resizeTextForBestFit = true;
         */
    }

    // Start is called before the first frame update
    void Awake()
    {
       // PrevButText = PrevMenu.gameObject.transform.GetComponentInChildren<Text>();
       // LangChangeText = LangChange.gameObject.transform.GetComponentInChildren<Text>();
       // LangChange.onClick.AddListener(
       //     () => { Localizator.Instance.ChangeLang(); }
       //     );

    }
    private void OnEnable()
    {
        base.OnEnable();
    }

    private void OnDisable()
    {
        base.OnDisable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
