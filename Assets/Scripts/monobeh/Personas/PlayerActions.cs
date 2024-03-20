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

    public QuestBoardUI qbui;
    public Inputs mInputs;
    bool action;
    bool quest = false;
    
    public GameObject raypoint;
    IInteracte interact;
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
                quest = !quest;
                QuestButton();
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
        
        if (quest)
        {
            PlayControl.Instance.SwitchPlayerState<UIViewState>();
        }
        else
        {
            PlayControl.Instance.SwitchPlayerState<MovingState>();

        }
        qbui.changeView();
        //if (!UICustomES.Instance.UIView)
        //{
        //    UICustomES.Instance.QuestBarShowT();
        //    UICustomES.Instance.InfoTextHideT();
        //}
    }

    private void ActionButton()
    {
        
        if (PlayControl.Instance._curState.GetType() == typeof(MovingState))
        {
            if (interact!=null) {
                interact.Show();
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
            if (PlayControl.Instance._curState.GetType() == typeof(MovingState))
            {
        if (Physics.Raycast(ray, out hit, 4f))
        {

                if (hit.collider.gameObject.TryGetComponent<IInteracte>(out interact))
                {
                    interact.Interaction();
                    //print(hit.collider.gameObject);
                }
        }
        else {
                //interact?.Hide();
                interact = null;
                ControlUI.Instance.InfoTextShowT("",false);
            }
       }
    }


}
/*
           switch (DetObj)
           {
               case ActionObj.None:
                   break;
               case ActionObj.Pacient:

                   ControlUI.Instance.Vocal(true);
                   PlayControl.Instance.SwitchPlayerState<UIViewState>();
                   //UICustomES.Instance.InfoTextHideT();
                   break;
               case ActionObj.Medcard:
                   ControlUI.Instance.MedCard(true);
                   PlayControl.Instance.SwitchPlayerState<UIViewState>();
                   //UICustomES.Instance.InfoTextHideT();
                   break;
               case ActionObj.Exit:
                   ControlUI.Instance.Result(true);
                   PlayControl.Instance.SwitchPlayerState<UIViewState>();
                   //UICustomES.Instance.ResultShowT();
                   //UICustomES.Instance.InfoTextHideT();
                   break;
               default:
                   break;
           }
            */

//QuestButton();
/*
//print(hit.collider.gameObject.name);
switch (hit.collider.gameObject.name)
{
    case "Pacient":
        DetObj = ActionObj.Pacient;
        ControlUI.Instance.InfoTextShowT(hit.collider.gameObject.name,true);
        //UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
        break;
    case "Exit":
        DetObj = ActionObj.Exit;
        ControlUI.Instance.InfoTextShowT(hit.collider.gameObject.name, true);
        //UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);//ui dynamic
        break;
    case "Medcard":
        ControlUI.Instance.InfoTextShowT(hit.collider.gameObject.name, true);
        //UICustomES.Instance.InfoTextShowT(hit.collider.gameObject.name);
        DetObj = ActionObj.Medcard;
        break;
    default:
        DetObj = ActionObj.None;
        //UICustomES.Instance.InfoTextHideT();
        break;
}
 */
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