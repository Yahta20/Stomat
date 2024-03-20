using System;
using UnityEngine;

[Serializable]
public struct Place
{

    public string name;//"MainList",
    public int[] size;//[1169 , 826],
    public int[] point;//[0,0]
    public int page;
    public Vector2 getSizeVector()
    {
        return new Vector2(size[0], size[1]);
    }
    public Vector2 getPointVector()
    {
        return new Vector2(point[0], point[1]);
    }

    internal void SetSize(Vector2 sizeDelta)
    {

        size = new int[2] { (int)(sizeDelta.x), (int)(sizeDelta.y) };
    }

    internal void SetPoint(Vector2 anchoredPosition)
    {
        point = new int[2] { (int)(anchoredPosition.x), (int)(anchoredPosition.y) };
    }
}