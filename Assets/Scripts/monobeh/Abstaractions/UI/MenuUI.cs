using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuUI : PageUI
{
    public List<PageUI> ChildList;
    public void ChangePage(PageUI t)
    {
        foreach (var item in ChildList)
        {

            if (item.GetType() == t.GetType())
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        ChangePage(ChildList[0]);
    }
    //protected abstract void setSize(Vector2 screen);
    public virtual void OnDisable() => base.OnDisable();
    public virtual void OnEnable() => base.OnEnable();
}
/*
 public virtual void OnDisable()
 public virtual void OnEnable()
 */