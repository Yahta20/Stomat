using System;
using System.Collections;
using UnityEngine;

public enum gameMode
{
    practical = 0,
    examinate = 1
}

public class Localizator : Singlton<Localizator>
{
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
    
    public Action OnChangetLang;
    private SystemLanguage currLang;

    public override void Awake()
    {
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
            string s = LocalizationText == null ? Resources.Load<TextAsset>("lang.json").text: LocalizationText.text;
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
        OnChangetLang?.Invoke();

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