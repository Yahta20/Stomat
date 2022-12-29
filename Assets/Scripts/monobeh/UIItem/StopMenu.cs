using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMenu : MonoBehaviour
{
    public RectTransform child;
    

    void OnEnable()
    {
        UICustomES.Instance.onPause += Show;
        UICustomES.Instance.offPause += Hide;
    }
    private void OnDisable()
    {
        UICustomES.Instance.onPause     -= Show;
        UICustomES.Instance.offPause    -= Hide;
    }
    private void Show()
    {
        child.gameObject.SetActive(true);
        UICustomES.Instance.ReleaseCursor();
    }

    private void Hide()
    {
        child.gameObject.SetActive(false);
        UICustomES.Instance.BlockCursor();
    }

    private void Start()
    {
        Draw();
        Hide();
    }

    private void Draw()
    {
        var ss = CanvasMaster.Instance.getSize();
        child.sizeDelta = ss * 0.32f;
        child.anchoredPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
