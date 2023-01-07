using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;
using System;
using UnityEngine.AddressableAssets;


public class ScenaController : MonoBehaviour
{
    public static ScenaController Instance { get {
            //if (instance == null)
            //{
            //    return new ScenaController();
            //}
                return instance;
            
        } set {
            instance = value;
        }
    }
    public static ScenaController instance { get; private set; }

    public Scene previosScene;
    public Scene currentScene;
    public SceneInstance loadScene;
    public event Action onChangeScene;
    //public event Action on;
    //public event Action onChangeScene;
    public GameState currentState { get; private set; }

    private void Awake()
    {
        if (instance == null)
        { // Ёкземпл€р менеджера был найден
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance != this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
        DontDestroyOnLoad(this);
        previosScene = SceneManager.GetActiveScene();
        currentScene = SceneManager.GetActiveScene();
        //onChangeScene += OnEnable;
    }
    private void OnDisable()
    {
        UICustomES.Instance.onBlockCursor   -= hideCursor;
        UICustomES.Instance.onReleaseCursor -= showCursor;
    }
    private void OnEnable()
    {
        ChekScene();
        UICustomES.Instance.onBlockCursor   += hideCursor;
        UICustomES.Instance.onReleaseCursor += showCursor;
    }
    private void Start()
    {
    }
        
    private void hideCursor()
    {
        currentState = GameState.moving;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void showCursor()
    {
        currentState = GameState.notes;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    private void ChekScene()
    {
        //kill duplikat
        var foundObjects = FindObjectsOfType<GameObject>();
        foreach (var item in foundObjects)
        {
            var chek = item.GetComponent<ScenaController>();
            if (chek != null & chek != Instance)
            {
                DestroyImmediate(item);
                break;
            }
        }
        // print("Der Eskapist E");
        //calibrate by scene
        if (SceneManager.GetActiveScene().name != "Cabinet")
        {
            currentState = GameState.moving;
        }
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    LoadScene(1);
        //}
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        currentScene = SceneManager.GetActiveScene();
        if (previosScene != currentScene)
        {
            if (onChangeScene!=null)
            {
            onChangeScene();
            }
            previosScene = currentScene;

        }
    }
    private void Managing()
    {

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            switch (currentState)
            {
                case GameState.moving:
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                    break;
                case GameState.notes:
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                    break;
            }
        }
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
        if (scene == 0)
        {
            currentState = GameState.notes;
        }
        SceneManager.LoadScene(scene);
    }

}
