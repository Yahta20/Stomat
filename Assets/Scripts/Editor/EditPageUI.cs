using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using KHNMU.Toolkit;
//[CustomEditor(typeof(FirstPageSM))]
[CustomEditor(typeof(PageUI),true)]

public class EditPageUI : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //PageUI cur = (PageUI)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Update CI"))
        {
            ((PageUI)target).UpdateCI();
        }
        if (GUILayout.Button("Update Congregation"))
        {
            ((PageUI)target).UpdateInfo();
        }
        GUILayout.EndHorizontal();//BeginHorizontal();
    }
}
