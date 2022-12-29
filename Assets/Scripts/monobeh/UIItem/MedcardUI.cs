using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedcardUI : MonoBehaviour
{
    RectTransform mainRect;
    void Awake()
    {
        mainRect = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        
    }
}
[Serializable]
public struct CardPlaces
{
    public Place[] DrawObgects;
    public Vector2 getByName(string s)
    {
        foreach (var item in DrawObgects)
        {
            if (item.name == s &
                item.size.Length == 2 &
                item.point.Length == 2
                )
            {
                return new Vector2(
                    item.size[0],
                    item.size[1]
                    );
            }
        }

        return Vector2.zero;
    }
    public void SetModif(Place p)
    {
        for (int i = 0; i < DrawObgects.Length; i++)
        {
            if (p.name == DrawObgects[i].name)
            {
                DrawObgects[i].size = p.size;
                DrawObgects[i].point = p.point;
            }
        }
    }


    public Place GetByName(string s)
    {
        foreach (var item in DrawObgects)
        {
            if (item.name == s &
                item.size.Length == 2
                )
            {
                return item;
            }
        }

        return new Place
        {
            name = "",
            size = new int[0],
            point = new int[0],
            page = 0
        };
    }
    public Place[] GetByPage(int p)
    {
        var res = new List<Place>();
        foreach (var item in DrawObgects)
        {
            if (
                item.name != "MainList" &
                item.page == p
                )
            {
                res.Add(item);
            }
        }
        return res.ToArray();
    }
    public Place[] GetAll2Draw(int p)
    {
        var res = new List<Place>();
        foreach (var item in DrawObgects)
        {
            if (
                item.name != "MainList"
                )
            {
                res.Add(item);
            }
        }
        return res.ToArray();
    }

}
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