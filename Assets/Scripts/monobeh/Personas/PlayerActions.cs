using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionObj { 
    None,
    Pacient,
    Medcard,
    Exit,
}

public class PlayerActions : MonoBehaviour
{
    
    
    public Inputs mInputs;
    bool action;
    bool quest;
    ActionObj DetObj;
    public GameObject raypoint;

    void Awake()
    {
        mInputs = new Inputs();
        mInputs.Player.Action.started +=
            ctx =>
            {
                ActionButton();
                action = true;
            };
        mInputs.Player.Quest.started +=
            ctx =>
            {
                QuestButton();
                quest = true;
        mInputs.Player.Pause.started +=
            ctx =>
            {
                print("as");
                //if (UICustomES.Instance.UIPaused)
                //{
                //    UICustomES.Instance.PauseOff();
                //}
                //else {
                //    UICustomES.Instance.PauseOn();
                //}
            };
            };
    }
    private void OnEnable()
    {
        mInputs.Enable();
    }
    private void OnDisable()
    {
        mInputs.Disable();
    }

    private void QuestButton()
    {
        print("q");
        //if (!UICustomES.Instance.UIView)
        //{
        //    UICustomES.Instance.QuestBarShowT();
        //    UICustomES.Instance.InfoTextHideT();
        //}
    }

    private void ActionButton()
    {
        
        if (!UICustomES.Instance.UIView)
        {
            switch (DetObj)
            {
                case ActionObj.None:
                    break;
                case ActionObj.Pacient:
                    
                    UICustomES.Instance.AskingBarShowT();
                    UICustomES.Instance.InfoTextHideT();
                    break;
                case ActionObj.Medcard:
                    
                    UICustomES.Instance.MedicalCardShowT();
                    UICustomES.Instance.InfoTextHideT();
                    break;
                case ActionObj.Exit:
                    UICustomES.Instance.ResultShowT();
                    UICustomES.Instance.InfoTextHideT();
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayRutine();
    }
    private void RayRutine()
    {
        Ray ray = new Ray(raypoint. transform.position, raypoint.transform.forward);
        RaycastHit hit;


        //Debug.DrawRay(raypoint.transform.position, raypoint.transform.forward, Color.green,4);
            if (ScenaController.Instance.currentState == GameState.moving)
            {
        if (Physics.Raycast(ray, out hit, 4f))
        {
                print(hit.collider.gameObject.name);
                switch (hit.collider.gameObject.name)
                {
                    case "Pacient":
                        DetObj = ActionObj.Pacient;
                        Singlton<UIControl>.Instance.InfoTextShowT(hit.collider.gameObject.name);
                        //UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                        break;
                    case "Exit":
                        DetObj = ActionObj.Exit;
                        Singlton<UIControl>.Instance.InfoTextShowT(hit.collider.gameObject.name);
                        //UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                        break;
                    case "Medcard":
                        Singlton<UIControl>.Instance.InfoTextShowT(hit.collider.gameObject.name);
                        //UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);
                        DetObj = ActionObj.Medcard;
                        break;
                    default:
                        DetObj = ActionObj.None;
                        //UICustomES.Instance.InfoTextHideT();
                        break;
                }
        }
        else {
            DetObj = ActionObj.None;
                Singlton<UIControl>.Instance.InfoTextShowT("");
            }
       }
    }


}

                //QuestButton();
                //print("wer");
        //mInputs.Player.Action.canceled +=
        //    ctx =>
        //    {
        //        action = false;
        //    };
                //print(quest);
                // quest = true;
                //print(quest);
        //mInputs.Player.Quest.canceled +=
        //    ctx =>
        //    {
        //        quest = false;
        //        //print(quest);
        //    };
                        //if (action)
                        //{
                        //    UIEventSystem.Instance.AskingBarShowT();
                        //    UIEventSystem.Instance.InfoTextHideT();
                        //}
                        //if (action)
                        //{
                        //    UIEventSystem.Instance.AskingBarShowT();
                        //    UIEventSystem.Instance.InfoTextHideT();
                        //}
            /*
            switch (ScenaManager.Instance.currentState)
            {
                case gamestate.moving:
                    switch (hit.collider.gameObject.name)
                    {
                        case "Pacient":
                            UIEventSystem.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                            if (action)
                            {
                                UIEventSystem.Instance.AskingBarShowT();
                                UIEventSystem.Instance.InfoTextHideT();
                            }
                            break;
                        case "Exit":
                            UIEventSystem.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                            if (action)
                            {
                                //ScenaManager.Instance.currentState = gamestate.asking;
                                //SceneManager.LoadScene(0);
                                UIEventSystem.Instance.ResultShowT();
                            }
                            break;
                        case "Medcard":
                            UIEventSystem.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                            if (action)
                            {
                                UIEventSystem.Instance.MedicalCardShowT();
                            }
                            break;
                        default:

                            break;

                    }
                    break;
                case gamestate.asking:
                    break;
                default:
                    //UIEventSystem.Instance.InfoTextHideT();
                    break;
            }
          */
        //    UIEventSystem.Instance.InfoTextHideT();
        //if (ScenaManager.Instance.currentState == gamestate.moving&& quest)
        //{
        //    UIEventSystem.Instance.AskingBarShowT();
        //}
            //UIEventSystem.Instance.QuestBarShowT();