using UnityEngine;

internal class UIViewState : BaseGameState
{
    public UIViewState(PlayControl control, IPlayerStateSwitcher ss) : base(control, ss)
    {
    }

    public override void CutScene()
    {
        
    }

    public override void Loading()
    {
    }

    public override void Moving()
    {
     
    }

    public override void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //_control.oper.animator.Play("CM_vcam1");
    }

    public override void Stop()
    {
      
    }

    public override void UIview()
    {
       
    }

    public override void Update()
    {
      
    }
}