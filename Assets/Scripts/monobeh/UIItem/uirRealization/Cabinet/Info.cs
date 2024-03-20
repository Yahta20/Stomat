using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    RectTransform _crt;
    Text _statelabel;
    // Start is called before the first frame update
    void OnEnable()
    {
        _crt = GetComponent<RectTransform>();
        _statelabel = GetComponent<Text>();
        _statelabel = GetComponent<Text>();
        ControlUI.Instance.onInfoTextShow += EventReaction;
        


    }
    private void SetSize()
    {
        var canvas = new Vector2(Screen.width, Screen.height);
        _crt.sizeDelta = new Vector2(canvas.x * 0.5f, canvas.y * 0.3f * 0.33f);
        _crt.anchoredPosition = new Vector2(0, -canvas.y * 0.25f);
        _statelabel.fontSize = (int)(canvas.y * 0.3f * 0.33f);
        _statelabel.color = Color.white;
    }


    private void EventReaction(string arg1, bool arg2)
    {
        if (arg2)
        {
            _statelabel.text = arg1;
        }
        else { _statelabel.text = ""; }
        SetSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
