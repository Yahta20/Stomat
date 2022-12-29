using UnityEngine;

[CreateAssetMenu(fileName = "ComfortablePlace", menuName = "ScriptableObjects/UI/Creare Dropdown Place", order = 9)]
public class ComfortDropdown : ComfortablePlace
{

    public ComfortImage currentImage;
    [Space]
    public ComfortText  Label;
    [Space]
    public ComfortImage Arrow;
    //public Sprite currentsprite;
    //public Color currentcolor;
    //public bool LabelalignByGeometry;
    //public int  LabelfontSize;
    //public bool LabelresizeTextForBestFit;
    //public Font Labelfont;
    //public bool LabelsupportRichText;
    //public Sprite Arrowsprite;
    //public Color Arrowcolor;
}
