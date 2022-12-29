using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosePage : MonoBehaviour
{
    public RectTransform    scrolView;
    public RectTransform    content;
    public GameObject       ButtonPrefab;
    public GridLayoutGroup  glgContent;
    public Text[]           langlabels;

    void Start()
    {
        glgContent.padding = new RectOffset(20, 20, 20, 20);
        glgContent.spacing = new Vector2(20,20);
        GenerateChoises();
    }

    private void GenerateChoises()
    {
        for (int i = 0; i < QuestMaster.Instance.Pacients.Length; i++)
        {
            var go = Instantiate(ButtonPrefab, content);
            var script = go.GetComponent<LevelButton>();
            
            script.SetNumber(i);
        }
    }



    // Update is called once per frame
    void LateUpdate()
    {
        updatingSize();
        UpgateLang();
    }
    private void UpgateLang()
    {
        if (langlabels.Length != 0)
        {
            for (int i = 0; i < langlabels.Length; i++)
            {
                langlabels[i].text = Localizator.Instance.GetLocalText(langlabels[i].gameObject.name);
            }
        }
    }
    private void updatingSize()
    {
        var ss = CanvasMaster.Instance.getSize();

        scrolView.sizeDelta = ss*0.82f;
        //content.sizeDelta
        glgContent.cellSize = new Vector2(scrolView.sizeDelta.x/2-60, scrolView.sizeDelta.y / 3 - 60);
        if (QuestMaster.Instance.Pacients.Length < 4)
        {
            content.sizeDelta =  new Vector2 (0, scrolView.sizeDelta.y);
        }
        else {
            var contentx = scrolView.sizeDelta.x;
            //QuestMaster.Instance.Pacients.Length / 3
            var contenty = (int)(QuestMaster.Instance.Pacients.Length / 3);

            //content.sizeDelta ;

        }
    }
}