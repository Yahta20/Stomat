using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour
{
    Text labelInfo;
    RectTransform rectTranc;

    void Awake()
    {
        labelInfo = GetComponent<Text>();
        rectTranc = GetComponent<RectTransform>();

    }
    private void Start()
    {
        makeDraw();
        TextHide();
    }

    private void makeDraw()
    {
        var ss = CanvasMaster.Instance.getSize();
        rectTranc.sizeDelta = new Vector3(ss.x*0.258f,ss.y*0.15f);//CanvasMaster.Instance.getSize();
        rectTranc.anchoredPosition = new Vector3(0, ss.y * 0.15f);
    }

    private void OnEnable()
    {
        UICustomES.Instance.onInfoTextShow += TextShow;
        UICustomES.Instance.onInfoTextHide += TextHide;

    }

    private void OnDisable()
    {

        UICustomES.Instance.onInfoTextShow -= TextShow;
        UICustomES.Instance.onInfoTextHide -= TextHide;
    }

    private void TextShow(string obj)
    {
        labelInfo.enabled = true;
        labelInfo.text = Localizator.Instance.GetLocalText($"ST_{obj}");

    }

    private void TextHide()
    {
        labelInfo.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
