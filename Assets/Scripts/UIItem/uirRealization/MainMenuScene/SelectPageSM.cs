using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPageSM : PageUI
{
    public GameObject LevelPrefab;
    [Space]
    public Button PrevMenu;
    public ScrollRect LevelsList;
    public GridLayoutGroup ContentLLG;
    
    
    Text PrevButText;

    protected override void setLang(SystemLanguage lang)
    {
        PrevButText.text = Localizator.Instance.GetLocalText(PrevMenu.gameObject.name);
    }

    protected override void setSize(Vector2 screen)
    {
        currentTransform.sizeDelta = screen;
        currentTransform.anchoredPosition = Vector2.zero;
        currentTransform.anchorMin = new Vector2(0.5f, 0.5f);
        currentTransform.anchorMax = new Vector2(0.5f, 0.5f);

        //previos menu button
        var PrevMenuRT = PrevMenu.GetComponent<RectTransform>();

        PrevMenuRT.anchorMin = new Vector2(0, 1);
        PrevMenuRT.anchorMax = new Vector2(0, 1);
        PrevMenuRT.pivot = new Vector2(0, 1);
        PrevMenuRT.sizeDelta = new Vector2(currentTransform.sizeDelta.x/10, currentTransform.sizeDelta.y / 16);
        PrevMenuRT.anchoredPosition = new Vector2(0, 0);
        PrevButText.resizeTextForBestFit = true;
        //Scroll menu button
        var LevelsListRT = LevelsList.GetComponent<RectTransform>();

        LevelsListRT.anchorMin = new Vector2(0.5f, 0.5f);
        LevelsListRT.anchorMax = new Vector2(0.5f, 0.5f);
        LevelsListRT.pivot = new Vector2(0.5f, 0.5f);
        LevelsListRT.sizeDelta = new Vector2(currentTransform.sizeDelta.x *0.62f, currentTransform.sizeDelta.y * 0.62f);
        LevelsListRT.anchoredPosition = new Vector2(0, 0);

        LevelsList.content.sizeDelta = Vector2.zero;

        var contspace = screen * 0.05f;
        var contcell = new Vector2(
            /*x*/(LevelsListRT.sizeDelta.x-contspace.x*4)/3,
            /*y*/((LevelsListRT.sizeDelta.x-contspace.x*4)/3)*0.62f
            );

        ContentLLG.padding = new RectOffset((int)contspace.x, (int)contspace.x, (int)contspace.y, (int)contspace.y);
        ContentLLG.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        ContentLLG.constraintCount = 3;
        ContentLLG.cellSize = contcell;
        ContentLLG.spacing = contspace;

        for (int i = 0; i < QuestMaster.Instance.Pacients.Length; i++)
        {
            var go = Instantiate(LevelPrefab, LevelsList.content);
        }
        if ((QuestMaster.Instance.Pacients.Length / 3) * (contcell.y + 2 * contspace.y) < LevelsListRT.sizeDelta.y)
        {
            LevelsList.content.sizeDelta = LevelsListRT.sizeDelta;
        }
        else {
            LevelsList.content.sizeDelta = new Vector2(
                LevelsListRT.sizeDelta.x,
                (QuestMaster.Instance.Pacients.Length / 3) * (contcell.y + 2 * contspace.y)
                ); 
        }

        // Rect menu



    }

    // Start is called before the first frame update
    void Awake()
    {
        PrevButText = PrevMenu.gameObject.transform.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
