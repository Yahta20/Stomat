using System;
using System.Collections.Generic;
using UnityEngine;


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
