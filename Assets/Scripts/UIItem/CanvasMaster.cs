using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMaster : MonoBehaviour
{

    public static CanvasMaster Instance;
    Canvas canvas;
    
    Image currImage;
    void Awake()
    {
        Instance = this;
        canvas = GetComponent<Canvas>();
    }

    public Vector2 getSize()
    {
        var a = canvas.GetComponent<RectTransform>().sizeDelta;
        return new Vector2(a.x, a.y);
    }

    private void FixedUpdate()
    {

    }

}
