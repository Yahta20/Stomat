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
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateView();
        UpgateLang();
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

        var ss = CanvasMaster.Instance.getSize();
        viewRect.sizeDelta = new Vector3(ss.x*0.32f, ss.y*0.68f*0.5f); 
        viewRect.anchoredPosition = new Vector3(0, viewRect.sizeDelta.y/2);
        ExitRect.sizeDelta = new Vector3(viewRect.sizeDelta.x,viewRect.sizeDelta.y/5);
        NGRect.sizeDelta = new Vector3  (viewRect.sizeDelta.x,viewRect.sizeDelta.y/5);
        OptRect .sizeDelta = new Vector3(viewRect.sizeDelta.x,viewRect.sizeDelta.y/5);
    }

}
