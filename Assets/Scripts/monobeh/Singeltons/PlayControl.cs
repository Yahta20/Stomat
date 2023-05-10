using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public enum GameState
{
    moving,
    notes,
    cutscene
}

public class PlayControl : Singlton<PlayControl>, IPlayerStateSwitcher
{

    protected override void  Awake()
    {
        base.Awake();

    }

    public Scene previosScene;
    public Scene currentScene;
    public SceneInstance loadScene;
    public event Action onChangeScene;

    private BaseGameState _curState;
    private List<BaseGameState> _diapState;

    void Start()
    {
        _diapState = new List<BaseGameState>()
        {
            new UIViewState(this,this),
            new CutsceneState(this,this),
            new LoadingState(this,this),
            new MovingState(this,this)
        };
        _curState = _diapState[0];
    }


    public void CutScene()
    {
        _curState.CutScene();
    }

    public void Loading()
    {
        _curState.Loading();
    }

    public void Moving()
    {
        _curState.Moving();
    }
    public void UIview()
    {
        _curState.UIview();
    }


    void Update()
    {
        _curState.Update();
    }

    public void SwitchPlayerState<T>() where T : BaseGameState
    {
        var state = _diapState.FirstOrDefault(f => f is T);
        _curState.Stop();
        state.Start();
        _curState = state;
    }
}
