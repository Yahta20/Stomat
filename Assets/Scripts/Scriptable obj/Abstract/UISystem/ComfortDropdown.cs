using UnityEngine;

[CreateAssetMenu(fileName = "ComfortablePlace", menuName = "ScriptableObjects/UI/Creare Dropdown Place", order = 9)]
public class ComfortDropdown : ComfortablePlace
{

    //public ComfortImage currentImage;
    public Sprite currentsprite;
    public Color currentcolor;
    [Space]
    //public ComfortText  Label;
    public bool LabelalignByGeometry;
    public int  LabelfontSize;
    public bool LabelresizeTextForBestFit;
    public Font Labelfont;
    public bool LabelsupportRichText;
    [Space]
    //public ComfortImage Arrow;
    public Sprite Arrowsprite;
    public Color Arrowcolor;
}
