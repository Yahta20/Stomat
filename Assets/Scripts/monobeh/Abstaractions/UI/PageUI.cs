using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor;
using KHNMU.Toolkit;

[InitializeOnLoad]
[RequireComponent(typeof(Image))]
public abstract class PageUI : MonoBehaviour
{
    protected Image         _Font;
    protected RectTransform _Transform;
    //protected PlaningUI     _Interier;

    /*
    recttransf
     */
    Text txt;// MaskableGraphic :Graphic : UIBehaviour          //*
    Image i;//create MaskableGraphic : Graphic, UIBehaviour,    //*
    Toggle t;//             Selectable : UIBehaviour,           //*
    ToggleGroup tg;//                   :UIBehaviour            //
    Dropdown dd;//           Selectable : UIBehaviour,          //*
    ScrollRect sr;//        ScrollRect : UIBehaviour,           //*
    InputField inf;//       Selectable : UIBehaviour            //*
    Scrollbar scb;//        Selectable : UIBehaviour,           //*
    Button btn;//           Selectable : UIBehaviour,           //*
    Slider sld;//           Selectable : UIBehaviour,           //*

    public ComfortImage _comfortImage;
    public List<UIBehaviour> _congregation;
    //public GameObject[] _congregation;

    public List<ComfortablePlace> _comfortablePlaceObjects;


    public virtual void OnDisable()
    {
        UICustomES.Instance.onChangeScreeSize -= setSize;
        Localizator.Instance.OnChangetLang -= setLang;
    }


    public virtual void OnEnable()
    {
        _Font     =GetComponent<Image>();
        _Transform=GetComponent<RectTransform>();
        UICustomES.Instance.onChangeScreeSize += setSize;
        Localizator.Instance.OnChangetLang += setLang;
        setSize(new Vector2(UICustomES.Instance.Resolution.width, UICustomES.Instance.Resolution.height));
        setLang(Localizator.Instance.CurrLang);
        //EditorApplication.update +=
        //UpdateInfo();
    }
    protected virtual void setSize(Vector2 screen) {
        //_comfortImage.setPLase(_Transform, screen);
        _Transform.sizeDelta        = _comfortImage.sizeDelta*screen;
        _Transform.anchoredPosition = _comfortImage.anchoredPosition * screen;  //new Vector2(0, _Transform.sizeDelta.y * 0.38f*0.5f); ;
        _Transform.anchorMin        = _comfortImage.anchorMin;                  //new Vector2(0.5f, 0);
        _Transform.anchorMax        = _comfortImage.anchorMax;                  //new Vector2(0.5f, 0);
        _Transform.pivot            = _comfortImage.pivot;                      //new Vector2(0.5f, 0);
        _Font.color                 = _comfortImage.color;
        //if (_congregation.Count == _comfortablePlaceObjects.Count)
        //{
        //    
        //    for (int i = 0; i < _congregation.Count; i++)
        //    {
        //        _comfortablePlaceObjects[i].setPLase(_congregation[i].GetComponent<RectTransform>(),screen);
        //    }
        //
        //}

    }
    protected abstract void setLang(SystemLanguage lang);
    //static
        //static
    public void UpdateInfo() {
        //_congregation = ToolKit.CreateChildList(this.gameObject);
        _congregation = ToolKit.CreateComponentList(this.gameObject);
    }


    //[MenuItem("Update CI")]
#if UNITY_EDITOR
    public void UpdateCI() {

        if (UnityEditor.EditorApplication.isPlaying == true)
        {
                var screen = new Vector2(UICustomES.Instance.Resolution.width, UICustomES.Instance.Resolution.height);
            if (_comfortImage != null)
            {
                UpdateIPlace(_comfortImage,_Font,screen);
            }
            else {
                var p = ToolKit.CreateSccriptableObject(new ComfortImage(), "Assets/Scripts/Scriptable obj/ScriptableObj/Places", 
                    this.GetType().ToString());
            }
        }
    }
    private void UpdateRTplace(ComfortablePlace so, RectTransform Rtransform,  Vector2 screen)
    {
        
        so.sizeDelta = Rtransform.sizeDelta / screen;
        so.anchoredPosition =
           Rtransform.anchoredPosition == Vector2.zero ? Vector2.zero : _Transform.sizeDelta / screen;
        so.anchorMin =   Rtransform.anchorMin;                  //new Vector2(0.5f, 0);
        so.anchorMax =   Rtransform.anchorMax;                  //new Vector2(0.5f, 0);
        so.pivot =       Rtransform.pivot;                      //new Vector2(0.5f, 0);
    }
    private void UpdateIPlace(ComfortImage so, Image i, Vector2 screen)
    {
        
        so.color = i.color;
        so.sprite = i.sprite;
        UpdateRTplace(so,i.GetComponent<RectTransform>(), screen);
    }
    private void UpdateTPlace(ComfortText tso, Text t, Vector2 screen)
    {
        //alignByGeometry     =;
        //fontSize            =;
        //resizeTextForBestFit=;
        //font                =;
        //supportRichText     =;
        UpdateRTplace(tso,t.GetComponent<RectTransform>(), screen);
    }
    public void PlansForChild()
    {
        for (int i = 0; i < _congregation.Count; i++)
        {
            //if (_congregation[i].GetComponent<Text>())//*
            if (_congregation[i].GetType()==typeof(Text))//*

            {
                ToolKit.CreateSccriptableObject(new ComfortText(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<>())//*
            if (_congregation[i].GetType() == typeof(Image))//*

            {
                ToolKit.CreateSccriptableObject(new ComfortImage(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Button>())//*
            if (_congregation[i].GetType() == typeof(Button))
            {
                ToolKit.CreateSccriptableObject(new ComfortButton(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Dropdown>())//*
            if (_congregation[i].GetType() == typeof(Dropdown))
            {
                ToolKit.CreateSccriptableObject(new ComfortDropdown(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<InputField>())//*
            if (_congregation[i].GetType() == typeof(InputField))
            {
                ToolKit.CreateSccriptableObject(new ComfortInput(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<ScrollRect>())//*
            if (_congregation[i].GetType() == typeof(ScrollRect))
            {
                ToolKit.CreateSccriptableObject(new ComfortScroll(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }

            if (_congregation[i].GetType() == typeof(Toggle))
                //if (_congregation[i].GetComponent<Toggle>())//*
            {
                ToolKit.CreateSccriptableObject(new ComfortToggle(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Scrollbar>())//*
            if (_congregation[i].GetType() == typeof(Scrollbar))

            {
                ToolKit.CreateSccriptableObject(new ComfortScrollbar(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Slider>())//*
            if (_congregation[i].GetType() == typeof(Slider))

            {
                ToolKit.CreateSccriptableObject(new ComfortSlide(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}|{_congregation[i].gameObject.name}");
            }
        }
    }

#endif

}   




                //_comfortImage.sizeDelta = _Transform.sizeDelta / screen;
                //_comfortImage.anchoredPosition =
                //_Transform.anchoredPosition == Vector2.zero ? Vector2.zero : _Transform.sizeDelta / screen;
                //_comfortImage.anchorMin = _Transform.anchorMin;                  //new Vector2(0.5f, 0);
                //_comfortImage.anchorMax = _Transform.anchorMax;                  //new Vector2(0.5f, 0);
                //_comfortImage.pivot = _Transform.pivot;                      //new Vector2(0.5f, 0);
                //_comfortImage.color = _Font.color;
                //_comfortImage.sprite = _Font.sprite;
                //var so = Resources.GetBuiltinResource(_comfortImage.GetType(), p);
                //screen/  _Transform.anchoredPosition     ;  //new Vector2(0, _Transform.sizeDelta.y * 0.38f*0.5f); ;
        //UnityEditor.EditorApplication.isPlaying == false;
        //if (Editor)
        //{
        //
        //}
        //
    //public List<RectTransform> cildItems;

    //protected List<UIBehaviour> cildItems;
    //protected List<Action> cildAction;

    
    
    







