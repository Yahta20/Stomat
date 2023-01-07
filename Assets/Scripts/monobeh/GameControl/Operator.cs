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
        animator.Play(cls.ToString());
        mInputs.Player.View.started +=
            ctx =>
            {
                View();
            };
        
    }



    private void View()
    {
        //var sts = ScenaController.Instance.currentState;
        if (PlayControl.Instance.CuState.GetType() == typeof(MovingState))
        {
            if (isfp)
            {
                //print(sts);
                animator.Play(CameraList.FV_Camera.ToString());
            }
            {
                animator.Play(CameraList.CM_vcam1.ToString());
            }
            isfp = !isfp;
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
        /*
        switch (PlayControl.Instance.CuState.GetType())
        {
            case typeof(MovingState):
                break;

            case typeof(MovingState):
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
            */
                //    print($"{cls}");
                //    cls = CameraList.FV_Camera;
                //    animator.Play(cls.ToString());
                //}
        //CM FreeLook2
        //FV Camera
        //    CM vcam1
