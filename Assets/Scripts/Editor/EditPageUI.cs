using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using KHNMU.Toolkit;
//[CustomEditor(typeof(FirstPageSM))]
[CustomEditor(typeof(PageUI),true)]
//[CustomEditor(typeof(PageUI))]

public class EditPageUI : Editor
{
    SerializedProperty damageProp;
    SerializedProperty armorProp;
    SerializedProperty gunProp;


    void OnEnable()
    {
        // Setup the SerializedProperties.
        damageProp = serializedObject.FindProperty("damage");
        armorProp = serializedObject.FindProperty("armor");
        gunProp = serializedObject.FindProperty("gun");
    }
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //PageUI cur = (PageUI)target;

 
         //ProgressBar (((PageUI)target)./ 100.0f, "Damage");



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
