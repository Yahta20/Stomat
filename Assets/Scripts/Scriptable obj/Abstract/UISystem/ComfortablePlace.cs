using System;

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ComfortablePlace", menuName = "ScriptableObjects/UI/Creare Place", order = 1)]
//[Serializable]
public class ComfortablePlace : ScriptableObject
{

    public Vector2 anchoredPosition     ;
    public Vector2 offsetMax            ;
    public Vector2 offsetMin            ;
    //public Rect     rect                    ;
    public Vector2 anchorMin            ;
    public Vector2 anchorMax            ;
    public Vector3 anchoredPosition3D   ;
    public Vector2 sizeDelta            ;
    public Vector2 pivot;

    public void setPLase(RectTransform rt,Vector2 sv) { 
            rt.anchoredPosition     =anchoredPosition   /sv;
            rt.sizeDelta            =sizeDelta          /sv;
            rt.offsetMax            =offsetMax          ;//*sv;
            rt.offsetMin            =offsetMin          ;//*sv;
            rt.anchorMin            =anchorMin          ;//*sv;
            rt.anchorMax            =anchorMax;//*sv;
            rt.pivot = pivot;//*sv;
                                                //rt.anchoredPosition3D   =anchoredPosition3D *sv;

    }

}


            //var xy = new Vector2(rect.x, rect.y);
            //var wh = new Vector2(rect.width, rect.height);

//rt.rect = new Rect(xy*sv, wh*sv);//               xy*sv;

//public int resizeTextMinSize { get; set; }
//public int resizeTextMaxSize { get; set; }
//public TextAnchor alignment { get; set; }
//public HorizontalWrapMode horizontalOverflow { get; set; }
//public VerticalWrapMode verticalOverflow { get; set; }
//public FontStyle fontStyle { get; set; }
//public float pixelsPerUnit { get; }
//public virtual float minWidth { get; }
//public virtual float preferredWidth { get; }
//public virtual float flexibleWidth { get; }
//public virtual float minHeight { get; }
//public virtual float preferredHeight { get; }
//public float lineSpacing { get; set; }
//public virtual float flexibleHeight { get; }
//public virtual string text { get; set; }
//public TextGenerator cachedTextGenerator { get; }
//public virtual int layoutPriority { get; }
// public override Texture mainTexture { get; }
//public TextGenerator cachedTextGeneratorForLayout { get; }
//Text
