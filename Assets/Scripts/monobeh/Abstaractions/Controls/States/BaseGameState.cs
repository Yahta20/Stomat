using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState: StateBase
{
    protected readonly PlayControl _control;
    protected readonly IPlayerStateSwitcher _stateSwith;
    protected BaseGameState(PlayControl control, IPlayerStateSwitcher ss)
    {
        control = _control;
        ss=_stateSwith;
    }

    
    public abstract void Moving();
    public abstract void CutScene();
    public abstract void UIview();
    public abstract void Loading();


}
