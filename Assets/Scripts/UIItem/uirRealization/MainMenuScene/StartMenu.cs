using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartMenu : MenuUI
{



    protected override void setLang(SystemLanguage lang)
    {
        
    }

    protected override void setSize(Vector2 screen)
    {
        _Transform.sizeDelta = screen;
        _Transform.anchoredPosition = Vector2.zero;
        _Transform.anchorMin = new Vector2(0.5f, 0.5f);
        _Transform.anchorMax = new Vector2(0.5f, 0.5f);
    }
    public void ExitApp()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

    private void Start()
    {
        base.Start();
    }


    //public List<UnityEvent> ActionsOfPages;
    //public PageUI startPage;
    //public List<PageUI> ChildList;
    //[Serializable]
    //public void ChangePage(PageUI t)
    //{
    //    foreach (var item in ChildList)
    //    {
    //        if (item.GetType() == t.GetType())
    //        {
    //            item.gameObject.SetActive(true);
    //        }
    //        else {
    //            item.gameObject.SetActive(false);
    //        }
    //    }
    //}
    //private void Awake()
    //{
    //    base.Awake();
    //}
    //void Start()
    //{
    //    base.Start();
    //}
    //
    //private void OnDisable()
    //{
    //    base.OnDisable();
    //}
    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
}
