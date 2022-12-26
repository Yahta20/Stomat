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

        if (GUILayout.Button("Update CI"))
        {
            ((PageUI)target).UpdateCI();
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Update Congregation"))
        {
            ((PageUI)target).UpdateInfo();
        }
        if (GUILayout.Button("Generate Child Plans"))
        {
            ((PageUI)target).PlansForChild();
        }
        GUILayout.EndHorizontal();//BeginHorizontal();
        if (GUILayout.Button("Update Plans"))
        {
            ((PageUI)target).UpdateChildPlans();
        }
    }
}
