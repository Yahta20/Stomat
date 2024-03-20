using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPage : MonoBehaviour
{
    public RectTransform viewRect;
    public RectTransform NGRect;
    public RectTransform OptRect;
    public RectTransform ExitRect;

    public Text[] langlabels;  


    // Start is called before the first frame update
    void Start()
    {
        Localizator.Instance.OnChangetLang += UpgateLang;
        
        UpgateLang();
        UpdateView();


    }

    // Update is called once per frame
    void LateUpdate()
    {
    }

    private void UpgateLang()
    {
        if (langlabels.Length!=0)
        {
            for (int i = 0; i < langlabels.Length; i++)
            {
                langlabels[i].text = Localizator.Instance.GetLocalText(langlabels[i].gameObject.name);
            }
        }
    }
    

    private void UpdateView()
    {
        var ss = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);// CanvasMaster.Instance.getSize();
        viewRect.sizeDelta          = new Vector2(ss.x*0.5f, ss.y*0.5f); 
        viewRect.anchoredPosition   = Vector2.zero;
        NGRect.     sizeDelta          = new Vector3(viewRect.sizeDelta.x/3,viewRect.sizeDelta.y/5);
        OptRect .   sizeDelta          = new Vector3(viewRect.sizeDelta.x/3,viewRect.sizeDelta.y/5);
        ExitRect.   sizeDelta          = new Vector3(viewRect.sizeDelta.x/3,viewRect.sizeDelta.y/5);
        NGRect.  anchoredPosition= new Vector3(0, -viewRect.sizeDelta.y / 6);
        OptRect .anchoredPosition= Vector2.zero;
        ExitRect.anchoredPosition= new Vector3(0, viewRect.sizeDelta.y / 6);
    }

}
