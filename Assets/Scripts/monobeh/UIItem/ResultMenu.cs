using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMenu : MonoBehaviour
{
    public GameObject Resblank;
    public Text resultText;
    public Text repeat;
    public Text exit;
    public Button repeatB;
    public Button mainmenuB;


    private void OnEnable()
    {
        UICustomES.Instance.onResultShow += Show;
        UICustomES.Instance.onResultHide += Hide;
    }
    void Start()
    {

        repeatB.onClick.AddListener(() => {
            PlayControl.Instance.LoadScene("Cabinet");
        });
        mainmenuB.onClick.AddListener(() => {

#if UNITY_EDITOR
            if (
            QuestMaster.Instance == null )
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }

#endif
            PlayControl.Instance.LoadScene(0);
        });
        Hide();
    }
    private void Hide()
    {
        PlayControl.Instance.SwitchPlayerState<MovingState>();
        UICustomES.Instance.BlockCursor();
        Resblank.SetActive(false);
    }


    private void Show()
    {
        PlayControl.Instance.SwitchPlayerState<UIViewState>();
        //UICustomES.Instance.ReleaseCursor();
        Resblank.SetActive(true);
        setText();
    }


    private void setText()
    {

        //print($"{QuestMaster.Instance == null}");
        //print($"{QuestMaster.Instance.currentPacient == null}");
        //print($"{QuestMaster.Instance.currentPacient == null} {QuestMaster.Instance.currentPacient.Grade().ToString()}");
        string qmi = QuestMaster.Instance == null ? "nun": QuestMaster.Instance.currentPacient.Grade().ToString();
        
        resultText.text = $"{Localizator.Instance.GetLocalText("ST_Grade")} >" + 

            $"{Localizator.Instance.GetLocalText($"ST_{qmi}")}<";
        
        repeat.text = $"{Localizator.Instance.GetLocalText(repeat.gameObject.name)}";
        
        exit.text = $"{Localizator.Instance.GetLocalText(exit.gameObject.name)}";
    }
    private void OnDisable()
    {
        UICustomES.Instance.onResultShow -= Show;
        UICustomES.Instance.onResultHide -= Hide;
    }
    // Update is called once per frame
    void Update()
    {
    }
}





        


