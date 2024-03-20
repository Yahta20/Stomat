using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public Button Exit;
    public Button Retry;
    public Text Info;




    void Start()
    {
        Exit.onClick.AddListener(() => { 
        
        });
        Retry.onClick.AddListener(() => { });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
