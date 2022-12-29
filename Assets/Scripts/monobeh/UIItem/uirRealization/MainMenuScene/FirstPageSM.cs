using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPageSM : PageUI
{
    public Button ChosenPage;
    public Button OptionsPage;
    public Button ExitPage;

 
    Text ChosenT;
    Text OptionsT;
    Text ExitT;
    
    //new public ComfortImage _comfortImage;
    //new public List<GameObject> _congregation;
    //new public List<ComfortablePlace> _comfortablePlaceObjects;
    protected override void setLang(SystemLanguage lang)
    {
        ChosenT .text = Localizator.Instance.GetLocalText(ChosenPage.gameObject.name); 
        OptionsT.text = Localizator.Instance.GetLocalText(OptionsPage.gameObject.name);
        ExitT   .text = Localizator.Instance.GetLocalText(ExitPage.gameObject.name);

    }
    protected override void setSize(Vector2 screen)
    {
        //main area
        //_Transform.sizeDelta = screen*0.38f*0.5f;
        //_Transform.anchoredPosition = new Vector2(0, _Transform.sizeDelta.y * 0.38f*0.5f); ;
        //_Transform.anchorMin = new Vector2(0.5f, 0);
        //_Transform.anchorMax = new Vector2(0.5f, 0);
        //_Transform.pivot= new Vector2(0.5f, 0);
        ////
        //_Font.color = new Color(0, 0, 0, 0);
        base.setSize(screen);
        var ChosenRT =ChosenPage. GetComponent<RectTransform>();
        var OptionsRT=OptionsPage.GetComponent<RectTransform>();
        var ExitRT  = ExitPage   .GetComponent<RectTransform>();

        /*

        ChosenRT.anchorMin = new Vector2(0.5f, 1);
        ChosenRT.anchorMax = new Vector2(0.5f, 1);
        ChosenRT.pivot = new Vector2(0.5f, 0.5f);
        ChosenRT.sizeDelta = new Vector2(_Transform.sizeDelta.x, _Transform.sizeDelta.y/4);
        ChosenRT.anchoredPosition = new Vector2(0,0); 

        OptionsRT.anchorMin = new Vector2(0.5f, 0.5f);
        OptionsRT.anchorMax = new Vector2(0.5f, 0.5f);
        OptionsRT.pivot = new Vector2(0.5f, 0.5f);
        OptionsRT.sizeDelta = new Vector2(_Transform.sizeDelta.x, _Transform.sizeDelta.y/4);
        OptionsRT.anchoredPosition = new Vector2(0, 0);

        ExitRT.anchorMin = new Vector2(0.5f, 0);
        ExitRT.anchorMax = new Vector2(0.5f, 0);
        ExitRT.pivot = new Vector2(0.5f, 0.5f);
        ExitRT.sizeDelta = new Vector2(_Transform.sizeDelta.x, _Transform.sizeDelta.y/4);
        ExitRT.anchoredPosition = new Vector2(0, 0);
         */

        ChosenT.resizeTextForBestFit = true; 
        OptionsT.resizeTextForBestFit = true;
        ExitT   .resizeTextForBestFit = true;

        //var ChosenTRT   = ChosenT .GetComponent<RectTransform>();
        //var OptionsTRT  = OptionsT.GetComponent<RectTransform>();
        //var ExitTRT     = ExitT   .GetComponent<RectTransform>();

        //ChosenTRT   =
        //OptionsTRT  =
        //ExitTRT     =



    }

    // Start is called before the first frame update
    void Awake()
    {
        
        ChosenT =ChosenPage .gameObject .transform.GetComponentInChildren<Text>();
        OptionsT=OptionsPage.gameObject .transform.GetComponentInChildren<Text>();
        ExitT   =ExitPage   .gameObject .transform.GetComponentInChildren<Text>();

    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }
    void Update()
    {
        
    }
}
