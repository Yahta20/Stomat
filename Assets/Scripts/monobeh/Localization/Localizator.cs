using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum gameMode
{
    practical = 0,
    examinate = 1
}

public class Localizator : Singleton<Localizator>, ISMInteractiv
{
    /*

    public static Localizator Instance { get //=>
        {
            if (_instance ==null)
            {
                Instance = new Localizator();
            }
            return _instance;

        }// _instance == null ? new Localizator(): _instance;
        set { _instance = value; }                                                           
    }
     */
    //public 
    static Localizator _instance;
    public TextAsset LocalizationText;
    public LocalizationMap currentLangPack;
    public SystemLanguage CurrLang { get {
                if (currLang==null)
                {
                currLang = Application.systemLanguage;
                }
                return currLang;
            } 
        private set {
            currLang = value;
        }
    }
    
    public Action<SystemLanguage> OnChangetLang;
    private SystemLanguage currLang;

    //public event Action onReleaseCursor;

    protected override void Awake()
    {
        /*
        //_instance.init();
        if (_instance ==  null)
        { // Экземпляр менеджера был найден
            _instance = this; // Задаем ссылку на экземпляр объекта
        DontDestroyOnLoad(this);
            return;
        }
        Destroy(gameObject); // Удаляем объект
         */
        base.Awake();
        loadLang();
    }
    
    private void loadLang()
    {
        //TODO make Adressable loading

        if (LocalizationText == null)
        {
            currentLangPack = new LocalizationMap();
        }
        else { 
        string s = LocalizationText == null ? Resources.Load<TextAsset>("lang").text: LocalizationText.text;
            currentLangPack = JsonUtility.FromJson<LocalizationMap>(s);
            currentLangPack.fillText();

        }
        CurrLang = SystemLanguage.Ukrainian;
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            CurrLang = SystemLanguage.Russian;
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            CurrLang = SystemLanguage.English;
        }
    }
    public string GetLocalText(string name) {
        string result="ERROR";
        if (currentLangPack.LangList != null)
        {
            for (int i = 0; i < currentLangPack.LangList.Length; i++)
            {
                if (currentLangPack.LangList[i].uiname==name)
                {
                    return currentLangPack.LangList[i].uiTextD[CurrLang];
                }
            }
        }
        return result;

    }
    public void ChangeLang() {
        switch (CurrLang)
        {
            case SystemLanguage.Ukrainian:
                CurrLang = SystemLanguage.Russian;
                break;
            case SystemLanguage.Russian:
                CurrLang = SystemLanguage.English;
                break;
            case SystemLanguage.English:
                CurrLang = SystemLanguage.Ukrainian;
                break;
        }
        OnChangetLang?.Invoke(CurrLang);

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
        //throw new NotImplementedException();
    }

    [Serializable]
public class serviceText
{

    public string uiname;
    public string[] uitext;
    public Dictionary<SystemLanguage, string> uiTextD = new Dictionary<SystemLanguage, string>();

    public void fillText()
    {
        uiTextD.Add(SystemLanguage.Ukrainian, uitext[0]);
        uiTextD.Add(SystemLanguage.Russian, uitext[1]);
        uiTextD.Add(SystemLanguage.English, uitext[2]);
    }

}
[Serializable]
public class LocalizationMap{

    public serviceText[] LangList;
    public void fillText() {
            if (LangList != null)
            {
                if (LangList.Length!=0)
                {

                    foreach (var item in LangList)
                    {
                        item.fillText();
                    }
                }
            }
    }
    }
}