using UnityEngine;

internal class MovingState : BaseGameState
{
    public MovingState(PlayControl control, IPlayerStateSwitcher ss) : base(control, ss)
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
    public override void UIview()
    {
     
    }

    public override void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Stop()
    {
     
    }


    public override void Update()
    {
       
    }
}