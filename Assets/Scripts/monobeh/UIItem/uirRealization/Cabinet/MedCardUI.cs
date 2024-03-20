using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MedCardUI : MonoBehaviour
{
    public Sprite[] pages;
    public TextAsset jsonFile;
    public Image CurrentImage;
    public RectTransform TextLoby;
    public CardPlaces topology;
    public GameObject prefab;
    public GameObject Toothprefab;

    private int pagenumber = 0;
    bool visiable = false;

    // Start is called before the first frame update
    private void OnEnable()
    {
        //Singlton<UIControl>.Instance.OnMedcard += Establid;
    }

    private void OnDisable()
    {
        CurrentImage.sprite = pages[0];
        topology = JsonUtility.FromJson<CardPlaces>(jsonFile.text);
        //Singlton<UIControl>.Instance.OnMedcard -= Establid;
    }

    public void NextPage()
    {
        pagenumber++;
        pagenumber = pagenumber > 5 ? 5 : pagenumber;
        CurrentImage.sprite = pages[pagenumber];
        SetSize();
    }
    public void PrevPage()
    {
        pagenumber--;
        pagenumber = pagenumber < 0 ? 0 : pagenumber;
        CurrentImage.sprite = pages[pagenumber];
        SetSize();
    }
    public void Show(bool obj)
    {
        visiable = obj;
    }
    private void SetSize()
    {
        var canvas = new Vector2(Screen.width, Screen.height);
        var MainList = topology.getByName("MainList");
        var scaler = (canvas.y / MainList.y) * 0.93f;
        var cursize = MainList * scaler;
        //print($"{MainList.x/MainList.y}|{canvas.x/canvas.y}");
        //print($"{canvas.y/MainList.y}|{canvas.x/ MainList.x}");
        //var partsToDraw = topology.GetByPage(pagenumber);
        //CleareContent(TextLoby,Vector2.zero);
        /*
        if (Field.Count + ToothField.Count != topology.DrawObgects.Length)
        {
            var list = topology.GetAll2Draw(pagenumber);
            for (int i = 0; i < list.Length; i++)
            {
                if (i >= Field.Count + ToothField.Count)
                {
                    if (!list[i].name.StartsWith("DC"))
                    {
                        var a = Instantiate(prefab, TextLoby);
                        a.name = list[i].name;
                        var field = a.GetComponent<AnswerMC>();
                        Field.Add(field);
                        field.Slavery(this);
                        field.Current(list[i], scaler);
                        field.MakeUpdate("");
                    }
                    if (list[i].name.StartsWith("DC"))
                    {
                        var a = Instantiate(Toothprefab, TextLoby);
                        a.name = list[i].name;
                        var field = a.GetComponent<ToothPanel>();
                        ToothField.Add(field);
                        field.Slavery(this);
                        field.Current(list[i], scaler);
                        field.MakeUpdate();
                        
                    }
                }
            }
        }

        for (int i = 0; i < Field.Count; i++)
        {
            if (Field[i].GetCurrent().page == pagenumber)
            {
                Field[i].SetVisible(true);
            }
            else
            {
                Field[i].SetVisible(false);
            }
        }
        for (int i = 0; i < ToothField.Count; i++)
        {
            if (ToothField[i].GetCurrent().page == pagenumber)
            {
                ToothField[i].SetVisible(true);
            }
            else
            {
                ToothField[i].SetVisible(false);
            }
        }
        CurrentImage.rectTransform.sizeDelta =
            cursize;
         */
    }

    private void Establid()
    {
       // Singlton<UIControl>.Instance.setOrator(Menu);
       // root = Singlton<UIControl>.Instance.doc.rootVisualElement;
       // Doduty();
    }

    private void Doduty()
    {
       // var btn = root.Q<Button>("closeCard");
       // btn.clicked += Singlton<UIControl>.Instance.InfoShowT;
    }

    // Update is called once per frame
    void Update()
    {
        if (visiable)
        {
            CurrentImage.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(CurrentImage.rectTransform.anchoredPosition.x, 0, Time.deltaTime * 3), 0);
        }
        else
        {
            CurrentImage.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(CurrentImage.rectTransform.anchoredPosition.x, Screen.width, Time.deltaTime * 3), 0);
        }
    }
}
