using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor;
using KHNMU.Toolkit;

//[InitializeOnLoad]
[RequireComponent(typeof(Image))]
public abstract class PageUI : MonoBehaviour
{
    protected Image         _Font;
    protected RectTransform _Transform;
    
    public ComfortImage _comfortImage;
    public List<UIBehaviour> _congregation;

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
    }
    protected virtual void setSize(Vector2 screen) {
        if (_comfortImage!=null)
        {
            SetImagePlaning(_comfortImage, _Font, screen);
        }
        if (_congregation.Count==_comfortablePlaceObjects.Count&
            _congregation.Count != 0&
            0!= _comfortablePlaceObjects.Count
            )
        {
            for (int i = 0; i < _congregation.Count; i++)
            {
                switch (_congregation[i])
                {
                    case Image:
                        if (_comfortablePlaceObjects[i].GetType() ==typeof(ComfortImage)  )
                        {
                            SetImagePlaning((ComfortImage)_comfortablePlaceObjects[i],(Image) _congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;
                    case Text:
                        if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortText))
                        {
                            SetTextPlaning((ComfortText)_comfortablePlaceObjects[i], (Text)_congregation[i], screen);
                            //SetImagePlaning((ComfortImage)_comfortablePlaceObjects[i], (Image)_congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;
                    case Button:
                        if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortButton))
                        {
                            SetButtonPlaning((ComfortButton)_comfortablePlaceObjects[i], (Button)_congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;
                    case ScrollRect:
                        if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortScroll))
                        {
                            SetScrollPlaning((ComfortScroll)_comfortablePlaceObjects[i], (ScrollRect)_congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;

                    case Toggle:
                        if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortToggle))
                        {

                            SetTogglePlaning((ComfortToggle)_comfortablePlaceObjects[i], (Toggle)_congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;
                    case Slider:
                        if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortSlide))
                        {
                            SetSlidePlaning((ComfortSlide)_comfortablePlaceObjects[i], (Slider)_congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;
                    case Dropdown:
                        if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortDropdown))
                        {
                            SetDropdownPlaning((ComfortDropdown)_comfortablePlaceObjects[i], (Dropdown)_congregation[i], screen);
                        }
                        else
                        {
                            print($"{_comfortablePlaceObjects[i]} has wrong type");
                        }
                        break;
                    default:
                        print($"{_congregation[i]} has wrong type");
                        break;

                }
            }
        }


        if (_congregation.Count != _comfortablePlaceObjects.Count)
        {
            print($"Diferent List size");
        }
        //_Transform.sizeDelta        = _comfortImage.sizeDelta*screen;
        //_Transform.anchoredPosition = _comfortImage.anchoredPosition * screen;  //new Vector2(0, _Transform.sizeDelta.y * 0.38f*0.5f); ;
        //_Transform.anchorMin        = _comfortImage.anchorMin;                  //new Vector2(0.5f, 0);
        //_Transform.anchorMax        = _comfortImage.anchorMax;                  //new Vector2(0.5f, 0);
        //_Transform.pivot            = _comfortImage.pivot;                      //new Vector2(0.5f, 0);
        //_Font.color                 = _comfortImage.color;
        
    }
    protected abstract void setLang(SystemLanguage lang);

    private void SetDropdownPlaning(ComfortDropdown so, Dropdown dd, Vector2 screen)
    {

        SetTextPlaning(so.Label, dd.captionText, screen);      
        SetImagePlaning(so.currentImage, dd.GetComponent<Image>(), screen);
        SetImagePlaning(so.Arrow, dd.transform.GetChild(1).GetComponent<Image>(), screen);
        SetRectPlaning(so, dd.GetComponent<RectTransform>(), screen);
    }
    private void SetTogglePlaning(ComfortToggle so, Toggle toggle, Vector2 screen)
    {

        SetImagePlaning(so.currentImage, toggle.GetComponentInChildren<Image>(), screen);
        SetImagePlaning(so.ChekMark, toggle.GetComponentInChildren<Image>().GetComponentInChildren<Image>(), screen);

        SetTextPlaning(so.Label,toggle.GetComponentInChildren<Text>(),screen);
        SetRectPlaning(so, toggle.GetComponent<RectTransform>(), screen);
    }


    private void SetRectPlaning(ComfortablePlace so,RectTransform transform,Vector2 screen)
    {
        transform.sizeDelta =           so.sizeDelta * screen;
        transform.anchoredPosition =    so.anchoredPosition * screen;  //new Vector2(0, _Transform.sizeDelta.y * 0.38f*0.5f); ;
        transform.anchorMin =           so.anchorMin;                  //new Vector2(0.5f, 0);
        transform.anchorMax =           so.anchorMax;                  //new Vector2(0.5f, 0);
        transform.pivot =               so.pivot;                      //new Vector2(0.5f, 0);
    }

    private void SetTextPlaning(ComfortText so, Text text, Vector2 screen)
    {
        text.alignByGeometry      =so.alignByGeometry      ;
        text.fontSize             =so.fontSize             ;
        text.resizeTextForBestFit =so.resizeTextForBestFit ;
        text.font                 =so.font                 ;
        text.supportRichText      =so.supportRichText      ;
        SetRectPlaning(so, text.rectTransform, screen);
    }
    private void SetImagePlaning(ComfortImage so, Image image, Vector2 screen)
    {
        image.color = so.color;
        image.sprite = so.sprite;
        SetRectPlaning(so,image.rectTransform,screen);
    }

    private void SetButtonPlaning(ComfortButton so, Button btn, Vector2 screen)
    {
        /*
        image.color = so.color;
        image.sprite = so.sprite;
         */
        var image = btn.image;
        var text = btn.GetComponentInChildren<Text>();
        SetImagePlaning((ComfortImage)so.image, image, screen);
        SetTextPlaning(((ComfortText)so.text), text, screen);
        SetRectPlaning(so, btn.GetComponent<RectTransform>(), screen);
    }
    private void SetScrollbarPlaning(ComfortScrollbar so, Scrollbar sb, Vector2 screen)
    {
        var image = sb.handleRect.GetComponent<Image>();
        SetImagePlaning((ComfortImage)so.handle, image, screen);
        SetRectPlaning(so, sb.GetComponent<RectTransform>(), screen);
    }
    private void SetScrollPlaning(ComfortScroll so, ScrollRect sr, Vector2 screen)
    {
        var image = sr.GetComponent<Image>();
        var vievPort = sr.viewport;
        var content = sr.content;
        var vscrolbar = sr.verticalScrollbar;
        var hscrolbar = sr.horizontalScrollbar;
        SetImagePlaning     (so.image, image, screen);
        SetRectPlaning      (so.viewPort, vievPort, screen);
        SetRectPlaning      (so.Content, content, screen);
        SetScrollbarPlaning (so.vertical, vscrolbar, screen);
        SetScrollbarPlaning (so.horizontal, hscrolbar, screen);
        SetRectPlaning(so, sr.GetComponent<RectTransform>(), screen);
    }

    private void SetSlidePlaning(ComfortSlide so, Slider sl, Vector2 screen)
    {
        /*
         public ComfortImage image;
    public ComfortablePlace viewPort;
    public ComfortablePlace Content;
    public ComfortScrollbar vertical;
    public ComfortScrollbar horizontal;
        var image = sr.GetComponent<Image>();
        var vievPort = sr.viewport;
        var content = sr.content;
        var vscrolbar = sr.verticalScrollbar;
        var hscrolbar = sr.horizontalScrollbar;
        SetRectPlaning(so.viewPort, vievPort, screen);
        SetRectPlaning(so.Content, content, screen);
        SetScrollbarPlaning(so.vertical, vscrolbar, screen);
        SetScrollbarPlaning(so.horizontal, hscrolbar, screen);
         */
        //sl.fillRect
        //    sl.fillRect


        SetImagePlaning(so.groundImage, sl.GetComponents<Image>()[0], screen);
        SetImagePlaning(so.groundFill, sl.fillRect.GetComponent<Image>(), screen);
        SetImagePlaning(so.groundHandle, sl.handleRect.GetComponent<Image>(), screen);
        SetRectPlaning(so, sl.GetComponent<RectTransform>(), screen);
    }


    private void SetScrollbarPlaning(ComfortScrollbar so, Scrollbar sb, Vector2 screen, params ScriptableObject[] list)
    {
        var image = sb.handleRect.GetComponent<Image>();
        SetImagePlaning((ComfortImage)list[0], image, screen);
        SetRectPlaning(so, sb.GetComponent<RectTransform>(), screen);
    }
    private void SetButtonPlaning(ComfortButton so, Button btn, Vector2 screen, params ScriptableObject[] list)
    {
        /*
        image.color = so.color;
        image.sprite = so.sprite;
         */
        var image = btn.image;
        var text = btn.GetComponentInChildren<Text>();
        SetImagePlaning ((ComfortImage)list[0],image,screen);
        SetTextPlaning  (((ComfortText)list[1]),text ,screen);
        SetRectPlaning(so, btn.GetComponent<RectTransform>(), screen);
    }
    private void SetScrollPlaning(ComfortScrollbar so, ScrollRect sr, Vector2 screen, params ScriptableObject[] list)
    {
        /*
         public ComfortImage image;
    public ComfortablePlace viewPort;
    public ComfortablePlace Content;
    public ComfortScrollbar vertical;
    public ComfortScrollbar horizontal;
         */
        var image = sr.GetComponent<Image>();
        var vievPort = sr.viewport;
        var content = sr.content;
        var vscrolbar = sr.verticalScrollbar;
        var hscrolbar = sr.horizontalScrollbar;
        SetImagePlaning((ComfortImage)list[0], image, screen);
        SetRectPlaning((ComfortablePlace)list[1], vievPort, screen);
        SetRectPlaning((ComfortablePlace)list[2], content, screen);
        SetScrollbarPlaning((ComfortScrollbar)list[3], vscrolbar, screen);
        SetScrollbarPlaning((ComfortScrollbar)list[4], hscrolbar, screen);
        SetRectPlaning(so, sr.GetComponent<RectTransform>(), screen);
    }


#if UNITY_EDITOR
    public void UpdateInfo() {
        _congregation = ToolKit.CreateComponentList(this.gameObject);
    }
    public void UpdateCI() {

        if (UnityEditor.EditorApplication.isPlaying == true)
        {
                var screen = new Vector2(UICustomES.Instance.Resolution.width, UICustomES.Instance.Resolution.height);
            if (_comfortImage != null)
            {

                //print(_Transform.sizeDelta);
                //print(_Font.rectTransform.anchoredPosition);
                UpdateIPlace(_comfortImage,_Font,screen);

            }
            else {
                var p = ToolKit.CreateSccriptableObject(new ComfortImage(), "Assets/Scripts/Scriptable obj/ScriptableObj/Places", 
                    this.GetType().ToString());
            }
        }
    }
    //RECTTRANSFORM
    private void UpdateRTplace(ComfortablePlace so, RectTransform Rtransform,  Vector2 screen)
    {
        print("sasa");
        so.sizeDelta = Rtransform.sizeDelta / screen;
        so.anchoredPosition =
           Rtransform.anchoredPosition == Vector2.zero ? Vector2.zero : Rtransform.anchoredPosition / screen;
        so.anchorMin =   Rtransform.anchorMin;                  //new Vector2(0.5f, 0);
        so.anchorMax =   Rtransform.anchorMax;                  //new Vector2(0.5f, 0);
        so.pivot =       Rtransform.pivot;                      //new Vector2(0.5f, 0);
    }
    //Image
    private void UpdateIPlace(ComfortImage so, Image i, Vector2 screen)
    {
        print("sasa");
        so.color = i.color;
        so.sprite = i.sprite;
        UpdateRTplace(so,i.GetComponent<RectTransform>(), screen);
    }
    //text
    private void UpdateTPlace(ComfortText tso, Text t, Vector2 screen)
    {
        print("sasa");
        UpdateRTplace(tso,t.GetComponent<RectTransform>(), screen);
        tso.alignByGeometry     =t.alignByGeometry;
        tso.fontSize            =t.fontSize;
        tso.resizeTextForBestFit=t.resizeTextForBestFit;
        tso.font                =t.font;
        tso.supportRichText     =t.supportRichText;
    }
    //Button
    private void UpdateBPlace(ComfortButton bso, Button btn, Vector2 screen)
    {
        print("sasa");
        UpdateRTplace   (bso, btn.GetComponent<RectTransform>(), screen);
        var image = btn.image;
        var text = btn.transform.GetChild(0).GetComponent<Text>();
        UpdateIPlace    (bso.image, image, screen);
        UpdateTPlace    (bso.text, text, screen);
    }
    //Dropdown
    private void UpdateDDPlace(ComfortDropdown so, Dropdown dd, Vector2 screen)
    {
        print("sasa");
        /*
        SetTextPlaning(so.Label, dd.captionText, screen);
        SetImagePlaning(so.currentImage, dd.GetComponent<Image>(), screen);
        SetImagePlaning(so.Arrow, dd.transform.GetChild(1).GetComponent<Image>(), screen);
        SetRectPlaning(so, dd.GetComponent<RectTransform>(), screen);
         */

        var image = dd.GetComponent<Image>();
        var text = dd.captionText;
        var arrow = dd.transform.GetChild(1).GetComponent<Image>();
        UpdateIPlace(so.currentImage, image, screen);
        UpdateIPlace(so.currentImage, arrow, screen);
        UpdateTPlace(so.Label, text, screen);
        UpdateRTplace(so, dd.GetComponent<RectTransform>(), screen);
    }
    //Input
    private void UpdateIPPlace(ComfortInput so, InputField ip, Vector2 screen)
    {
        print("sasa");

        /*
        var image = dd.GetComponent<Image>();
        var text = dd.captionText;
        var arrow = dd.transform.GetChild(1).GetComponent<Image>();
        UpdateIPlace(so.currentImage, image, screen);
        UpdateIPlace(so.currentImage, arrow, screen);
        UpdateTPlace(so.Label, text, screen);
        UpdateRTplace(so, dd.GetComponent<RectTransform>(), screen);
         */
    }
    //Scrollbar
    private void UpdateSBPlace(ComfortScrollbar so, Scrollbar sb, Vector2 screen)
    {
        print("sasa");
        var image = sb.handleRect.GetComponent<Image>();
        UpdateIPlace(so.handle, image, screen);
        UpdateRTplace(so, sb.GetComponent<RectTransform>(), screen);
    }
    //ScrollRect
    private void UpdateSRPlace(ComfortScroll so, ScrollRect sr, Vector2 screen)
    {
        print("sasa");
        //
        //var image = sb.handleRect.GetComponent<Image>();
        //UpdateIPlace(so.handle, image, screen);
        var image = sr.GetComponent<Image>();
        var vievPort = sr.viewport;
        var content = sr.content;
        var vscrolbar = sr.verticalScrollbar;
        var hscrolbar = sr.horizontalScrollbar;

        UpdateIPlace(so.image, image, screen);
        UpdateRTplace(so.viewPort, vievPort, screen);
        UpdateRTplace(so.Content, content, screen);
        UpdateSBPlace(so.vertical, vscrolbar, screen);
        UpdateSBPlace(so.horizontal, hscrolbar, screen);
        UpdateRTplace(so, sr.GetComponent<RectTransform>(), screen);

        
        /*
        SetImagePlaning     (so.image, image, screen);
        SetRectPlaning      (so.viewPort, vievPort, screen);
        SetRectPlaning      (so.Content, content, screen);
        SetScrollbarPlaning (so.vertical, vscrolbar, screen);
        SetScrollbarPlaning (so.horizontal, hscrolbar, screen);
        SetRectPlaning(so, sr.GetComponent<RectTransform>(), screen);
         */
        


    }
    //Toggle
    private void UpdateTGPlace(ComfortToggle so, Toggle tg, Vector2 screen) {
        print("sasa");
        UpdateIPlace(so.currentImage, tg.GetComponentInChildren<Image>(), screen);
        UpdateIPlace(so.ChekMark, tg.GetComponentInChildren<Image>().GetComponentInChildren<Image>(), screen);

        UpdateTPlace(so.Label, tg.GetComponentInChildren<Text>(), screen);
        SetRectPlaning(so, tg.GetComponent<RectTransform>(), screen);
    }



    public void UpdateChildPlans()
    {
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            print($"updating...");
            UpdateCI();
            var screen = new Vector2(UICustomES.Instance.Resolution.width, UICustomES.Instance.Resolution.height);
            if (_congregation.Count == _comfortablePlaceObjects.Count &
                _congregation.Count != 0 &
                0 != _comfortablePlaceObjects.Count
                )
            {
                for (int i = 0; i < _congregation.Count; i++)
                {
                    switch (_congregation[i])
                    {
                        case Image:
                            if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortImage))
                            {
                                UpdateIPlace((ComfortImage)_comfortablePlaceObjects[i], (Image)_congregation[i], screen);
                            }
                            else
                            {
                                print($"{_comfortablePlaceObjects[i]} has wrong type");
                            }
                            break;
                        case Text:
                            if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortText))
                            {
                                UpdateTPlace((ComfortText)_comfortablePlaceObjects[i], (Text)_congregation[i], screen);
                            }
                            else
                            {
                                print($"{_comfortablePlaceObjects[i]} has wrong type");
                            }
                            break;
                        case Button:
                            if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortButton))
                            {
                                UpdateBPlace((ComfortButton)_comfortablePlaceObjects[i], (Button)_congregation[i], screen);
                            }
                            else
                            {
                                print($"{_comfortablePlaceObjects[i]} has wrong type");
                            }
                            break;
                        case ScrollRect:
                            if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortScroll))
                            {
                                UpdateSRPlace((ComfortScroll)_comfortablePlaceObjects[i], (ScrollRect)_congregation[i], screen);
                            }
                            else
                            {
                                print($"{_comfortablePlaceObjects[i]} has wrong type");
                            }
                            break;

                        case Toggle:
                            if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortToggle))
                            {

                                UpdateTGPlace((ComfortToggle)_comfortablePlaceObjects[i], (Toggle)_congregation[i], screen);
                            }
                            else
                            {
                                print($"{_comfortablePlaceObjects[i]} has wrong type");
                            }
                            break;
                        case Dropdown:
                            if (_comfortablePlaceObjects[i].GetType() == typeof(ComfortDropdown))
                            {
                                UpdateDDPlace((ComfortDropdown)_comfortablePlaceObjects[i], (Dropdown)_congregation[i], screen);
                            }
                            else
                            {
                                print($"{_comfortablePlaceObjects[i]} has wrong type");
                            }
                            break;
                        default:
                            print($"{_congregation[i]} has wrong type");
                            break;

                    }
                }
            }
        }
        print($"updating finish");

    }
    public void PlansForChild()
    {
        for (int i = 0; i < _congregation.Count; i++)
        {
            //if (_congregation[i].GetComponent<Text>())//*
            if (_congregation[i].GetType()==typeof(Text))//*

            {
                ToolKit.CreateSccriptableObject(new ComfortText(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<>())//*
            if (_congregation[i].GetType() == typeof(Image))//*

            {
                ToolKit.CreateSccriptableObject(new ComfortImage(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Button>())//*
            if (_congregation[i].GetType() == typeof(Button))
            {
                ToolKit.CreateSccriptableObject(new ComfortButton(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Dropdown>())//*
            if (_congregation[i].GetType() == typeof(Dropdown))
            {
                ToolKit.CreateSccriptableObject(new ComfortDropdown(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<InputField>())//*
            if (_congregation[i].GetType() == typeof(InputField))
            {
                ToolKit.CreateSccriptableObject(new ComfortInput(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<ScrollRect>())//*
            if (_congregation[i].GetType() == typeof(ScrollRect))
            {
                ToolKit.CreateSccriptableObject(new ComfortScroll(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }

            if (_congregation[i].GetType() == typeof(Toggle))
                //if (_congregation[i].GetComponent<Toggle>())//*
            {
                ToolKit.CreateSccriptableObject(new ComfortToggle(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Scrollbar>())//*
            if (_congregation[i].GetType() == typeof(Scrollbar))

            {
                ToolKit.CreateSccriptableObject(new ComfortScrollbar(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
            //if (_congregation[i].GetComponent<Slider>())//*
            if (_congregation[i].GetType() == typeof(Slider))

            {
                ToolKit.CreateSccriptableObject(new ComfortSlide(), $"Assets/Scripts/Scriptable obj/ScriptableObj/Places",
                $"{this.GetType().ToString()}_{_congregation[i].GetType()}_{_congregation[i].gameObject.name}");
            }
        }
    }

#endif

}   


        //EditorApplication.update +=
        //UpdateInfo();
        //_comfortImage.setPLase(_Transform, screen);
        //if (_congregation.Count == _comfortablePlaceObjects.Count)
        //{
        //    
        //    for (int i = 0; i < _congregation.Count; i++)
        //    {
        //        _comfortablePlaceObjects[i].setPLase(_congregation[i].GetComponent<RectTransform>(),screen);
        //    }
        //
        //}
    //static
        //static
        //_congregation = ToolKit.CreateChildList(this.gameObject);

    //[MenuItem("Update CI")]

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
