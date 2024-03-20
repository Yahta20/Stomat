using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedcardBeh : MonoBehaviour, IInteracte
{
    public MedCardUI MedcardUI;


    public void Hide()
    {
        PlayControl.Instance.SwitchPlayerState<MovingState>();
        MedcardUI.Show(false);

    }

    public void Interaction()
    {
        ControlUI.Instance.InfoTextShowT(
       Localizator.Instance.GetLocalText($"ST_{gameObject.name}")
           , true);
    }

    public void Show()
    {
        ControlUI.Instance.InfoTextShowT(
        Localizator.Instance.GetLocalText($"ST_{gameObject.name}")
            , false);
        PlayControl.Instance.SwitchPlayerState<UIViewState>();
        MedcardUI.Show(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
