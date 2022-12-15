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

public class PlayControl : Singlton,IPlayerStateSwitcher
{

    private void Awake()
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
            new CutsceneState(this,this),
            new LoadingState(this,this)
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlayerState<T>() where T : BaseGameState
    {
        var state = _diapState.FirstOrDefault(f => f is T);
        _curState.Stop();
        state.Start();
        _curState = state;
    }
}
