using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacientBeh : MonoBehaviour, IInteracte
{


    public VocalUI uiimplement;
    
    
    
    public void Hide()
    {
        PlayControl.Instance.SwitchPlayerState<MovingState>();
        ControlUI.Instance.Vocal(false);
        //uiimplement.Show(false);
    }

    public void Interaction()
    {
        ControlUI.Instance.InfoTextShowT(
        Localizator.Instance.GetLocalText("ST_Pacient")
            , true);

    }

    public void Show()
    {
        ControlUI.Instance.InfoTextShowT(
        Localizator.Instance.GetLocalText($"ST_{gameObject.name}")
            , false);
        PlayControl.Instance.SwitchPlayerState<UIViewState>();
        uiimplement.Show(true);

    }
    private void Start()
    {
        
    }

}
