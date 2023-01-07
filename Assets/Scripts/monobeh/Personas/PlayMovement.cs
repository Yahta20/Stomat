using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayMovement : MonoBehaviour
{

    public Inputs mInputs;
    public Animator animator;
    private Vector2 m_Rotation;
    public float moveSpeed;
    public float rotateSpeed;

    public float rotationLerp = 0.5f;
    //public float burstSpeed;
    public GameObject followTransform;
    
    private Vector2 move;
    private Vector2 look;
    private Quaternion nextRotation;
    private Vector3 nextPosition;
    private Vector2 smoothDeltaPosition = Vector2.zero;
    public Vector2 velocity = Vector2.zero;
    public float speed;

    public void Awake()
    {
        mInputs =new Inputs();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        mInputs.Enable();
    }
    private void OnDisable()
    {
        mInputs.Disable();
    }

    private void FixedUpdate()
    {
        move = mInputs.Player.Moving.ReadValue<Vector2>();
        look = mInputs.Player.Look.ReadValue<Vector2>();
    }
        
    public void Update()
    {
        if (
            PlayControl.Instance.CuState.GetType() == typeof(MovingState))
            //ScenaController.Instance.currentState==GameState.moving
        {
            Looking();
            Moving();
        }
    }



    private void Moving()
    {
        Vector3 worldDeltaPosition = nextPosition - transform.position;

        //Map to local space
        float dX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dX, dY);

        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        if (Time.deltaTime > 1e-5f)
        {
            velocity = smoothDeltaPosition / Time.deltaTime;
        }

    }

    private void Looking()
    {
        transform.rotation *= Quaternion.AngleAxis(look.x * rotateSpeed, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(look.x * rotateSpeed, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(look.y * rotateSpeed, Vector3.right);
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;
        var angle = followTransform.transform.localEulerAngles.x;
        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }
        followTransform.transform.localEulerAngles = angles;
        nextRotation = Quaternion.Lerp(followTransform.transform.rotation, nextRotation, Time.deltaTime * rotationLerp);
        if (move.x == 0 && move.y == 0)
        {
            nextPosition = transform.position;
            return;
        }
        float moveSpeed = speed / 100f;
        Vector3 position = (transform.forward * move.y * moveSpeed) + (transform.right * move.x * moveSpeed);
        nextPosition = transform.position + position;
        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
    
    private void OnAnimatorMove()
    {
            //ScenaController.Instance.currentState == GameState.moving
        if (PlayControl.Instance.CuState.GetType() == typeof(MovingState)
            ) { 
            transform.position = nextPosition;
        //var movment = Vector2.ClampMagnitude(move,1);
        animator.SetFloat("MovementX", move.x);
        animator.SetFloat("MovementY", move.y);
        }
    }
        

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        //m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = m_Rotation;
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.localEulerAngles = m_Rotation;
        transform.position += move * scaledMoveSpeed;
    }
}



