using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class MenuUI : MonoBehaviour
{

    public UIDocument doc;
    public VisualElement root;
    public List<PageUI> ChildList;
    

    private void Awake()
    {
      init();
    }
        
    private void OnEnable()
    {
    
    }

    protected virtual void init()
    {
        PageUI p;
        for (int i = 0; i <  transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent<PageUI>(out p))
            {
                p.master = this;
                ChildList.Add(p);
            }
            else {
                Destroy(
                transform.GetChild(i)
                    );
            }
            transform.GetChild(i).gameObject.SetActive(false);
        } 

    }
    


}



