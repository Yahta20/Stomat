using System;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ComfortablePlace", menuName = "ScriptableObjects/UI/Creare ScrollPlace", order = 6)]
public class ComfortScroll : ComfortablePlace {

    public ComfortImage image;
    public ComfortablePlace viewPort;
    public ComfortablePlace Content;
    public ComfortScrollbar vertical;
    public ComfortScrollbar horizontal;

}

