
using UnityEngine;
[CreateAssetMenu(fileName = "ComfortablePlace", menuName = "ScriptableObjects/UI/Creare Button Place", order = 5)]
public class ComfortButton : ComfortImage
{

    //public ComfortImage image;
    //public ComfortText text;
    public Sprite sprite;
    public Color color;
    [Space]
    public bool alignByGeometry;
    public int fontSize;
    public bool resizeTextForBestFit;
    public Font font;
    public bool supportRichText;
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
