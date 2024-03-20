using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteracte
{

    public ResultUI _ResultUI;

    public void Hide()
    {
        ControlUI.Instance.InfoTextShowT(
            Localizator.Instance.GetLocalText("ST_Exit")
                , false);
    }

    public void Interaction()
    {
        ControlUI.Instance.InfoTextShowT(
         Localizator.Instance.GetLocalText("ST_Exit")
             , true);
    }

    public void Show()
    {
        ControlUI.Instance.InfoTextShowT(
           Localizator.Instance.GetLocalText("ST_Exit")
               , false);
        PlayControl.Instance.SwitchPlayerState<UIViewState>();
        PlayControl.Instance.LoadScene(0);

    }

}
