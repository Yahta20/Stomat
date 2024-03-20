
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
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

    public override void  Awake()
    {
        base.Awake();
        _diapState = new List<BaseGameState>()
        {
            new UIViewState(this,this),
            new CutsceneState(this,this),
            new LoadingState(this,this),
            new MovingState(this,this)
        };
        _curState = _diapState[0];
    }


    public Scene previosScene;
    public Scene currentScene;
    public SceneInstance loadScene;
    public event Action<BaseGameState> onChangeState;
    //public Operator oper;

    public BaseGameState _curState { get; private set; }
    private List<BaseGameState> _diapState;

    
    
    void Start()
    {

    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += sceneLoaded;

    }

    public void LoadScene(string scene)
    {
        Addressables.LoadSceneAsync(scene, LoadSceneMode.Single).Completed += (asyncHandle) =>
        {
            loadScene = asyncHandle.Result;
        };
    }
    public void LoadScene(int scene)
    {
        
        SceneManager.LoadScene(scene);
    }

    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "MainMenu")
        {
            SwitchPlayerState<UIViewState>();
        }
        if (arg0.name == "Cabinet")
        {
            //oper = FindObjectOfType<Operator>();
            SwitchPlayerState<MovingState>();

        }
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
        onChangeState?.Invoke(_curState);
    }
}
