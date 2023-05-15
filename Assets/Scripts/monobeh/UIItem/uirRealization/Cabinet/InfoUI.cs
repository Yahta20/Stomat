using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.UIElements;

public class InfoUI : MonoBehaviour
{
    public VisualTreeAsset Menu;
    public VisualElement root;
    Label text;

    void Start()
    {
        Establid();
    }

    private void OnEnable()
    {
        Singlton<UIControl>.Instance.OnInfo += TextShow;
        Singlton<UIControl>.Instance.onInformation += Establid;

    }

    private void Establid()
    {
        Singlton<UIControl>.Instance.setOrator(Menu);
        root = Singlton<UIControl>.Instance.doc.rootVisualElement;
        text = root.Q<Label>("info-label");
        text.text = "";
    }

    private void TextShow(string obj)
    {
        if (obj != "")
        {
            text.text = Singlton<Localizator>.Instance.GetLocalText($"ST_{obj}");;
        }
        else {
            text.text = obj;
        }
    }

    void Update()
    {
        
    }
}
