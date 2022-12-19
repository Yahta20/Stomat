using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(fileName = "Interier", menuName = "ScriptableObjects/UI/Creare Interier", order = 1)]
public class UIInterier : ScriptableObject
{
    PageUI _currentplace; 
    
    public GameObject[] _congregation;
    
    public ComfortablePlace[] _comfortablePlace;
    public void SetPageUI(PageUI pui) {
        pui = _currentplace;
    }
    // public GameObject _congregation;
    // public List<RectTransform> _comfortablePlace;
}