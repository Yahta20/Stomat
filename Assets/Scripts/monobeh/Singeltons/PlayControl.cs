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

public class PlayControl : Singleton<PlayControl>,IPlayerStateSwitcher, ISMInteractiv
{

    protected override void Awake()
    { 
        base.Awake();
        previosScene = SceneManager.GetActiveScene();
        currentScene = SceneManager.GetActiveScene();
        SceneManager.activeSceneChanged += ActiveSceneChanged ;
        SceneManager.sceneUnloaded      += SceneUnloaded;
        SceneManager.sceneLoaded        += SceneLoaded;
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
    public event Action onChangeScene;

    public BaseGameState CuState { get => _curState;}

    private BaseGameState _curState;
    private List<BaseGameState> _diapState;

    void Start()
    {
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


    private void hideCursor()
    {
        //currentState = GameState.moving;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void showCursor()
    {
        //currentState = GameState.notes;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        _curState.Update();
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
    private void OnEnable()
    {
        currentScene = SceneManager.GetActiveScene();
        if (previosScene != currentScene)
        {
            if (onChangeScene != null)
            {
                onChangeScene();
            }
            previosScene = currentScene;

        }
    }
    public void SwitchPlayerState<T>() where T : BaseGameState
    {
        var state = _diapState.FirstOrDefault(f => f is T);
        _curState.Stop();
        state.Start();
        _curState = state;
        //print($"Stateswitched to {state}");
    }

    void ISMInteractiv.ActiveSceneChanged(Scene arg0, Scene arg1)
    {
       // throw new NotImplementedException();

    }

    void ISMInteractiv.SceneUnloaded(Scene arg0)
    {
       // throw new NotImplementedException();

    }

    void ISMInteractiv.SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
      //  throw new NotImplementedException();

    }
}
