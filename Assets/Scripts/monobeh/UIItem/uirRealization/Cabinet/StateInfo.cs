
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class StateInfo:MonoBehaviour
{
    RectTransform _crt;
    Text _statelabel;

    //bool _active = false;
    string  info ="";
    float   duration=0;


    void OnEnable()
    {
        _crt = GetComponent<RectTransform>();
        _statelabel = GetComponent<Text>();
        ControlUI.Instance.onStatusTextShow += EventReaction;
        SetSize();

    }

    private void SetSize()
    {
        var canvas = new Vector2(Screen.width, Screen.height);
        _crt.sizeDelta = new Vector2(canvas.x*0.5f, canvas.y*0.3f);
        _statelabel.fontSize = (int)(canvas.y * 0.3f * 0.33f);
        _statelabel.color = Color.grey;
    }

    private void EventReaction(string arg1, int arg2)
    {
        info = arg1;
        duration = arg2;
        SetSize();
    }

    private void FixedUpdate()
    {
        if (duration > 0)
        {
            _statelabel.text = info;
        }
        else {
            info = "";
            duration = 0;
        }
        duration = duration > 0 ? duration - Time.deltaTime :0;
    }
}
