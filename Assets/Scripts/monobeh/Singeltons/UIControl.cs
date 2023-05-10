using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UIControl : Singlton<UIControl>
{

    public UIDocument doc;
    public MonoBehaviour currentOrator;

    // Start is called before the first frame update
    void Awake()
    {
        base.Awake();
        doc = GetComponent<UIDocument>();

    }

    public void setOrator(VisualTreeAsset b) {
        doc.visualTreeAsset = b;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
