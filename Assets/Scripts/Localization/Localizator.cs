using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameMode
{
    practical = 0,
    examinate = 1
}

public class Localizator : MonoBehaviour
{
    public static Localizator Instance { get; private set; }
    public TextAsset LocalizationText;
    public LocalizationMap currentLangPack;
    public SystemLanguage currLang { get; private set; }
    public Action<SystemLanguage> OnChangetLang;
    //public event Action onReleaseCursor;

    private void Awake()
    {
        if (Instance == null)
        { // Ёкземпл€р менеджера был найден
            Instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (Instance != this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
        DontDestroyOnLoad(this);
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
        currLang = SystemLanguage.Ukrainian;
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            currLang = SystemLanguage.Russian;
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            currLang = SystemLanguage.English;
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
                    return currentLangPack.LangList[i].uiTextD[currLang];
                }
            }
        }
        return result;

    }
    public void ChangeLang() {
        switch (currLang)
        {
            case SystemLanguage.Ukrainian:
                currLang = SystemLanguage.Russian;
                break;
            case SystemLanguage.Russian:
                currLang = SystemLanguage.English;
                break;
            case SystemLanguage.English:
                currLang = SystemLanguage.Ukrainian;
                break;
        }
        OnChangetLang?.Invoke(currLang);

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