using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
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
    }
}
