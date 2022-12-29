using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    public Text     buttonText;
    public Button   currentbutton;
    int PacientNumber;
    
    void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        currentbutton= GetComponent<Button>();
        currentbutton.onClick.AddListener(clicToCabinet);
    }


    
    void Update()
    {
        UpdateLang();
    }

    private void UpdateLang()
    {
        string txt = $"{Localizator.Instance.GetLocalText($"PD_PA_{PacientNumber+1}_Name_1")}\n{Localizator.Instance.GetLocalText($"PD_PA_{PacientNumber+1}_DateOfBirth_3")}";
        //print(PacientNumber) ;
        buttonText.text = txt;
    }



    public void SetNumber(int i) {
        PacientNumber = i;
    }
    void clicToCabinet() {
        QuestMaster.Instance.SetPatient(PacientNumber);
        ScenaController.Instance.LoadScene("Cabinet");
    }
}
