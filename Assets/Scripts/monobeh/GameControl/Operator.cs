using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public Inputs mInputs;
    public Animator animator;

    public bool isfp;

    enum CameraList {
         CM_FreeLook2
        ,FV_Camera
        ,CM_vcam1
    }

    CameraList cls = CameraList.CM_vcam1;
    
    void Awake()
    {
        mInputs = new Inputs();
        animator = GetComponent<Animator>();

        isfp = true;
        animator.Play(CameraList.FV_Camera.ToString());
        mInputs.Player.View.started +=
            _ => View();
        
    }



    private void View()
    {
        var sts = ScenaController.Instance.currentState;
        switch (sts)
        {
            
            case GameState.moving:
                if (isfp)
                {
                    print(sts);
                    //animator.Play(CameraList.CM_FreeLook2.ToString());
                }
                {
                    //animator.Play(CameraList.FV_Camera.ToString());
                }
                isfp = !isfp;


                break;
            case GameState.notes:
                
                break;
        }
    }
    private void OnEnable()
    {
        mInputs.Enable();
    }
    private void OnDisable()
    {
        mInputs.Disable();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}




                //if (cls == CameraList.FV_Camera)
                //{
                //print($"{cls}");
                //    cls = CameraList.CM_FreeLook2;
                //    animator.Play(cls.ToString());
                //}
                //if (cls == CameraList.CM_FreeLook2)
                //{
                //    print($"{cls}");
                //    cls = CameraList.FV_Camera;
                //    animator.Play(cls.ToString());
                //}
                //if (cls == CameraList.CM_vcam1)
                //{
                //    print($"{cls}");
                //    cls = CameraList.FV_Camera;
                //    animator.Play(cls.ToString());
                //}
        //CM FreeLook2
        //FV Camera
        //    CM vcam1
