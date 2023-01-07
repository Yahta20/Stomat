﻿using UnityEngine;

internal class LoadingState : BaseGameState
{
    public LoadingState(PlayControl control, IPlayerStateSwitcher ss) : base(control, ss)
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