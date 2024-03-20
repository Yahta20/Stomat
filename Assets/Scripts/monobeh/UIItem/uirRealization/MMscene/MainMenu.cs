using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    public GameObject FirstPage;
    public GameObject ChosePage;
    public GameObject Options;




    void Start()
    {
        ShowFirstPage();
    }

    public void ShowFirstPage()
    {
        FirstPage.SetActive(true);
        ChosePage.SetActive(false);
        Options.SetActive(false);
    }
    public void ShowChosePage()
    {
        FirstPage.SetActive(false);
        ChosePage.SetActive(true);
        Options.SetActive(false);
    }
    public void ShowOptionsPage()
    {
        FirstPage.SetActive(false);
        ChosePage.SetActive(false);
        Options.SetActive(true);
    }


    public void ExitApp() {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
