using KHNMU.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{

    public UIDocument menuDoc;
    public VisualTreeAsset Menu;
    public VisualTreeAsset patientBtn;

    VisualElement root;
    VisualElement mainPage;
    VisualElement pacientPage;
    VisualElement settingPage;
    VisualElement quitPage;
    

    public void ExitApp()
    {
        ToolKit.ExitApp();
    }
    private void Start()
    {

        root = menuDoc.rootVisualElement;
        SetupMenu();
    }

    private void OnEnable()
    {
        Singlton<Localizator>.Instance.OnChangetLang += SetupMenu;
    }

    private void OnDisable()
    {
        Singlton<Localizator>.Instance.OnChangetLang -= SetupMenu;
    }
        
    //{
    //}

    private void ChangeLang()
    {



        //




    }

    private void SetupMenu() {
        root = menuDoc.rootVisualElement;

        mainPage = root.Q<VisualElement>("mainPage");
        pacientPage = root.Q<VisualElement>("patientPage");
        settingPage = root.Q<VisualElement>("settingPage");
        quitPage = root.Q<VisualElement>("quitPage");
        //ListView
        var listoflevels = root.Q<VisualElement>("PatientBoard");
        
        //print(Singlton<QuestMaster>.Instance.Pacients.Length);
        for (int i = 0; i < Singlton<QuestMaster>.Instance.Pacients.Length; i++)
           //for (int i = 0; i < 2; i++)

            {
                var operatbtn = patientBtn.CloneTree();
                var curbtn = operatbtn.Q<Button>("patientBtn");
                curbtn.text = Singlton<Localizator>.Instance.GetLocalText(
                    $"PD_PA_{i+1}_Name_1"
                );
                //i.ToString()
                //QuestMaster.Instance.Pacients[i].PasportData[0]
                //Localizator.Instance.GetLocalText() 
            curbtn.clicked += delegate { LevelStart(i-1); };
            listoflevels.hierarchy.Add(curbtn);
            }


        //listoflevels.Add()
        mainPage.style.display = DisplayStyle.Flex;
        pacientPage.style.display = DisplayStyle.None;
        settingPage.style.display = DisplayStyle.None;
        quitPage.style.display = DisplayStyle.None;



        var ngbtn = root.Q<Button>("chPacient");
        var optbtn = root.Q<Button>("options");
        var exitbtn = root.Q<Button>("exitButton");
        var quitGame = root.Q<Button>("quit-accept");


        var back =  pacientPage.Q<Button>("Back-to-Main");
        var back1 = settingPage.Q<Button>("Back-to-Main");
        var back2 = quitPage.Q<Button>("Back-to-Main");
        //var back3 = root.Q<Button>("Back-to-Main");



        //var optbtn = root.Q<Button>("options");
        //var ngbtn = root.Q<Button>("chPacient");


        //var planebtn = root.Q<VisualElement>("buttonPlane");
        //planebtn.AddToClassList("hide");




        
        
        
        back.clicked += menuButton;
        back1.clicked += menuButton;
        back2.clicked += menuButton;
        
        ngbtn.clicked += patientButton;
        optbtn.clicked += settingButton;
        exitbtn.clicked += exitButton;
        quitGame.clicked += ExitApp;

        var loco = Singlton<Localizator>.Instance;
        mainPage.Q<Label>("GameName").text = loco.GetLocalText("GameName");
        mainPage.Q<Button>("chPacient").text = loco.GetLocalText("chPacient");
        mainPage.Q<Button>("options").text = loco.GetLocalText("options");
        mainPage.Q<Button>("exitButton").text = loco.GetLocalText("exitButton");
        root.Q<Button>("quit-accept").text = loco.GetLocalText("quit-accept") ;

        pacientPage.Q<Button>   ("Back-to-Main").text=loco.GetLocalText ("regect") ;
        settingPage.Q<Button>   ("Back-to-Main").text=loco.GetLocalText ("regect") ;
        quitPage.Q<Button>      ("Back-to-Main").text= loco.GetLocalText("regect");
    }

    private void LevelStart(int pacient)
    {

        Singlton<QuestMaster>.Instance.SetPatient(pacient);
        ScenaController.Instance.LoadScene("Cabinet");

    }

    private void exitButton() {
        mainPage.style.display = DisplayStyle.None;
        pacientPage.style.display = DisplayStyle.None;
        settingPage.style.display = DisplayStyle.None;
        quitPage.style.display = DisplayStyle.Flex;

    }

    private void settingButton()
    {
        mainPage.style.display = DisplayStyle.None;
        pacientPage.style.display = DisplayStyle.None;
        settingPage.style.display = DisplayStyle.Flex;
        quitPage.style.display = DisplayStyle.None;

    }
    private void patientButton()
    {
        mainPage.style.display = DisplayStyle.None;
        pacientPage.style.display = DisplayStyle.Flex;
        settingPage.style.display = DisplayStyle.None;
        quitPage.style.display = DisplayStyle.None;

    }
    private void menuButton()
    {
        mainPage.style.display = DisplayStyle.Flex;
        pacientPage.style.display = DisplayStyle.None;
        settingPage.style.display = DisplayStyle.None;
        quitPage.style.display = DisplayStyle.None;

    }

}



// protected override void setLang(SystemLanguage lang)
// {
// }
//     
//
// protected override void setSize(Vector2 screen)
// {
// }
//var exitbtn = root.Q<Button>("exitButton");
//exitbtn.clicked += () => ExitApp();
//_Transform.sizeDelta = screen;
//_Transform.anchoredPosition = Vector2.zero;
//_Transform.anchorMin = new Vector2(0.5f, 0.5f);
//_Transform.anchorMax = new Vector2(0.5f, 0.5f);
////_Font.color = new Color(0,0,0,0);
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
