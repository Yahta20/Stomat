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
                if (UICustomES.Instance.UIPaused)
                {
                    UICustomES.Instance.PauseOff();
                }
                else {
                    UICustomES.Instance.PauseOn();
                }
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
        if (!UICustomES.Instance.UIView)
        {
            UICustomES.Instance.QuestBarShowT();
            UICustomES.Instance.InfoTextHideT();
        }
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
            //ScenaController.Instance.currentState == GameState.moving
            if (
            PlayControl.Instance.CuState.GetType() == typeof(MovingState))
            {
        if (Physics.Raycast(ray, out hit, 4f))
        {
                //print(hit.collider.gameObject.name);
                switch (hit.collider.gameObject.name)
                {
                    /*
                    case "Pacient":
                        DetObj = ActionObj.Pacient;
                        UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                        //Message msg = new Message(this, "InfoTextShowT",
                        //    new object[1] { hit.collider.gameObject.name }, new Type[1] { typeof(string) });
                        //UICustomES.Instance.takeMail("InfoTextShowT", msg);
                            
                        //    );
                        break;
                    case "Exit":
                        DetObj = ActionObj.Exit;
                        UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
                        break;
                    case "Medcard":
                        UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);
                        DetObj = ActionObj.Medcard;
                        break;
                    default:
                        DetObj = ActionObj.None;
                        UICustomES.Instance.InfoTextHideT();
                        break;
                     */
                }
        }
        else {
                /*
            DetObj = ActionObj.None;
            UICustomES.Instance.InfoTextHideT();
                 */
        }
       }
    }
}
