using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomES : MonoBehaviour
{
    public static UICustomES Instance
    {
        get
        {
            if (instance == null)
            {
                return new UICustomES();
            }
            return instance;

        }
        set
        {
            instance = value;
        }
    }
    static UICustomES instance;

    public event Action <string> onInfoTextShow;
    public event Action onInfoTextHide;

    public event Action onMedicalCardShow;
    public event Action onMedicalCardHide;

    public event Action onAskingBarShow;
    public event Action onAskingBarHide;

    public event Action onQuestBarShow;
    public event Action onQuestBarHide;

    public event Action onResultShow;
    public event Action onResultHide;

    public event Action onBlockCursor;
    public event Action onReleaseCursor;

    public event Action onPause;
    public event Action offPause;

    public event Action <Vector2> onChangeScreeSize;
    Resolution currentResolution;
    public Resolution Resolution { get { return currentResolution;}}
    public Vector2 screenResolution { get { return new Vector2(currentResolution.width, currentResolution.height);  } }

    public bool UIView { get; private set; } = false;
    public bool UIPaused { get; private set; } = false;

    public void InfoTextShowT(string name)
    {
            onInfoTextShow?.Invoke(name);
    }
    public void InfoTextHideT()
    {
        if (onInfoTextHide != null)
        {
            onInfoTextHide();
        }
    }
    public void MedicalCardShowT()
    {
        if (onMedicalCardShow != null)
        {
            onMedicalCardShow();
        }
    }
    public void MedicalCardHideT()
    {
        if (onMedicalCardHide != null)
        {
            onMedicalCardHide();
        }
    }
    public void AskingBarShowT()
    {
        if (onAskingBarShow != null)
        {
            onAskingBarShow();
        }
    }
    public void AskingBarHideT()
    {
        if (onAskingBarHide != null)
        {

            onAskingBarHide();
        }
    }
    public void QuestBarShowT()
    {
        if (onQuestBarShow != null)
        {
            onQuestBarShow();
        }
    }
    public void QuestBarHideT()
    {

        if (onQuestBarHide != null)
        {
            onQuestBarHide();
        }
    }
    public void ResultShowT()
    {
        onResultShow?.Invoke();
    }
    public void ResultHideT()
    {
            onResultHide?.Invoke();
    }
    public void PauseOn() {
        if (onPause!=null)
        {
            onPause();
            UIPaused = true;
        }
    }
    public void PauseOff()
    {
        if (offPause != null)
        {
            offPause();

            UIPaused = false;
        }
    }
    public void BlockCursor()
    {
            UIView = false;
        if (onBlockCursor != null)
        {
            onBlockCursor();
        }
    }
    public void ReleaseCursor()
    {

            UIView = true;
        if (onReleaseCursor != null)
        {
            onReleaseCursor();
        }
    }
    private void Awake()
    {
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        DontDestroyOnLoad(this);
        currentResolution = Screen.currentResolution;
            return;
        }

            Destroy(gameObject); // Удаляем объект

    }
    private void FixedUpdate()
    {
        if (currentResolution.height !=         Screen.currentResolution.height & 
            currentResolution.refreshRate !=    Screen.currentResolution.refreshRate &
            currentResolution.width !=          Screen.currentResolution.width)
        {
            currentResolution = Screen.currentResolution;
            onChangeScreeSize?.Invoke(new Vector2(currentResolution.width, currentResolution.height));
        }
        //print($"{currentResolution}");
    }

}

