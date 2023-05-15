using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MedCardUI : MonoBehaviour
{
    public VisualTreeAsset Menu;
    public VisualElement root;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Singlton<UIControl>.Instance.OnMedcard += Establid;
    }
   


    private void Establid()
    {
        Singlton<UIControl>.Instance.setOrator(Menu);
        root = Singlton<UIControl>.Instance.doc.rootVisualElement;
        Doduty();
    }

    private void Doduty()
    {
        var btn = root.Q<Button>("closeCard");
        btn.clicked += Singlton<UIControl>.Instance.InfoShowT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
