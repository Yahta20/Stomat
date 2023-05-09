using KHNMU.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstPageSM : PageUI
{
    
 
    
    
    
    
    
    protected override void setLang(SystemLanguage lang)
    {
    }
    
  
    protected override void setSize(Vector2 screen)
    {
        
        var exitbtn = master.root.Q<Button>("exitButton");
        var optbtn = master.root.Q<Button>("options");
        var ngbtn = master.root.Q<Button>("chPacient");

        //var planebtn = root.Q<VisualElement>("buttonPlane");
        //planebtn.AddToClassList("hide");


        ngbtn.clicked+=() => {
            print("sasa");
            //master.ChangePage(master.ChildList[1]);
        };
        optbtn.clicked += () => {
            print("sasas");
            //master.ChangePage(master.ChildList[2]);
        };
        exitbtn.clicked += () => {
            print("sassa");
            //master.ChangePage(master.ChildList[3]);
        };
        //exitbtn.RegisterCallback<MouseUpEvent>((evt) => {
        //    planebtn.ToggleInClassList("hide");
        //});
        exitbtn.RegisterCallback<MouseUpEvent>((evt) => {
            //master.ChangePage(master.ChildList[3]);

            //ToolKit.ExitApp();
        });



    }
        



    void Awake()
    {
        

    }

    public override void OnEnable()
    {
        base.OnEnable();

    }

    private void Start()
    {
        setSize(Vector2.zero);
        
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }
    void Update()
    {
        
    }
}
