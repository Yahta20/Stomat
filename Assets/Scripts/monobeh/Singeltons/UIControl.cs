using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UIControl : Singlton<UIControl>
{

    public UIDocument doc;
    public MonoBehaviour currentOrator;


    public event Action<string> OnInfo;

    public event Action onInformation;
    public event Action OnMedcard;
    public event Action OnVocal;
    public event Action OnResult;




    public void InfoTextShowT(string name)
    {
        OnInfo?.Invoke(name);
    }
    public void MedcardShowT()
    {
        OnMedcard?.Invoke();
    }
    public void ResultShowT()
    {
        OnResult?.Invoke();
    }
    public void VocalShowT()
    {
        OnVocal?.Invoke();
    }
    public void InfoShowT()
    {
        PlayControl.Instance.SwitchPlayerState<MovingState>();
        onInformation?.Invoke();
    }

    // Start is called before the first frame update
    void Awake()
    {
        base.Awake();
        doc = GetComponent<UIDocument>();

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded+= unsetOrator;
        
        //unsetOrator();
    }
    public void setOrator(VisualTreeAsset b) {
        doc.visualTreeAsset = b;
    }
    public void unsetOrator(Scene s,LoadSceneMode lm)
    {
        doc.visualTreeAsset = new VisualTreeAsset();
    }

}
