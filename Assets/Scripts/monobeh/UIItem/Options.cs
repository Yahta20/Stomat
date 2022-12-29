using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Button LangButton;
    public Text[] langlabels;

    // Start is called before the first frame update
    void Start()
    {
        if (LangButton!=null)
        {
            LangButton.onClick.AddListener(Localizator.Instance.ChangeLang);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
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
}
