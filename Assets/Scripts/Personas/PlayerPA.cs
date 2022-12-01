using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPA : MonoBehaviour
{
  
    public Transform leftFootTarget;
    public Transform rightFootTarget;
    
    private Vector3 initLeftFootPos;
    private Vector3 initRightFootPos;

    private Vector3 lastLeftFootPos;
    private Vector3 lastRightFootPos;
    
    private Vector3 lastBodyPos;
    public float balancingMinorRadius =  0.25f ;
    public float balancingMajorRadius = 0.75f ;
                                   
                                   

    // Start is called before the first frame update

    void Start()
    {
        initLeftFootPos = leftFootTarget.localPosition;
        initRightFootPos = rightFootTarget.localPosition;
        lastLeftFootPos = leftFootTarget.position;
        lastRightFootPos = rightFootTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        //leftFootTarget.position = lastLeftFootPos;
        //rightFootTarget.position = lastRightFootPos;
        //lastLeftFootPos = leftFootTarget.position;
        //lastRightFootPos = rightFootTarget.position;
        if ( ! IsBalanced ( ) )
           MakeStep ( ) ;
        else
            StickToTheGround ( ) ;
        /*
         */
 




    }

    private void MakeStep()
    {
        Vector3 velocity = transform.position - lastBodyPos;
        Vector3 centerOfMass = transform.position;
        float leftFootDistance = Vector3.Distance(leftFootTarget.position, centerOfMass);
        float rightFootDistance = Vector3.Distance(rightFootTarget.position, centerOfMass);


        // If the left foot is further
        /*
        if (leftFootDistance >= rightFootDistance)
        {
            Vector3 nextPosition    = NextStep(rightFootTarget.position, centerOfMass);
            Vector3[] posAndNormal  = CastOnSurface(nextPosition, 2f, transform.up);
            leftFootTarget.position = posAndNormal[0];
        }
        else
        {
            Vector3 nextPosition    = NextStep(leftFootTarget.position, centerOfMass);
            Vector3[] posAndNormal  = CastOnSurface(nextPosition, 2f, transform.up);
            leftFootTarget.position = posAndNormal[0];

        }
         */
        lastLeftFootPos = leftFootTarget.position;
        lastRightFootPos = rightFootTarget.position;
           
    }
    private void StickToTheGround()
    {
        lastLeftFootPos = leftFootTarget.position;
        lastRightFootPos = rightFootTarget.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(leftFootTarget.position, 0.2f);
        Gizmos.DrawWireSphere(rightFootTarget.position, 0.2f);
        Debug.DrawLine(transform.position, transform.position + transform.up * 2f);
    }
    static Vector3[] ProjectOnSurface(Vector3 point, float halfRange, Vector3 up)
    {
        Vector3[] res = new Vector3[2];
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(point.x, point.y + halfRange, point.z), -up);
        if (Physics.Raycast(ray, out hit, 2f * halfRange))
        {
            res[0] = hit.point;
            res[1] = hit.normal;
        }
        else

            res[0] = point;
        return res;
    }

    public static Vector2 Rotate20(Vector2 v, float delta) {
        return new Vector2(
             v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
             v.x * Mathf.Sin(delta) - v.y * Mathf.Cos(delta)
             );
   
    }
    bool IsInEllipse(Vector2 point, Vector2 center, float minorRadius, float majorRadius)
    {
        return Mathf.Pow((point.x - center.x) / majorRadius, 2f) + Mathf.Pow((point.y - center.y) / minorRadius, 2f) <= 1f;
    }

    bool IsBalanced()
    {

        Vector3 ellipseCenter = (leftFootTarget.position +rightFootTarget.position ) / 2f;
        ellipseCenter = Vector3.ProjectOnPlane(ellipseCenter, transform.up);
        Vector2 ellipseCenter2D = new Vector2(ellipseCenter.x, ellipseCenter.z);
        Vector3 point = Vector3.ProjectOnPlane(transform.position, transform.up);
        Vector2 point2D = new Vector2(point.x, point.z);
        //Vector3 feetAxis =Vector3.ProjectOnPlane((rightFootTarget.position - leftFootTarget.position) , transform.up ).normalized;
        //Vector2 feetAxis2D = new Vector2(feetAxis.x, feetAxis.z);
        //Vector2 pointRotated = Rotate2D(point2D, GetAngle2D(feetAxis2D, Vector2.right));
        return IsInEllipse(point2D, ellipseCenter2D, balancingMinorRadius, balancingMajorRadius);
    }
    /*
  */
}
/*

bool IsBalanced ( )
    Vector3 ellipseCenter ( leftFootTarget position + right FootTarget.position ) / 2f ;
    ellipseCenter Vector3.ProjectOnPlane ( ellipseCenter , transform.up ) ;
    Vector2 ellipseCenter2D = new Vector 2 ( ellipseCenter.x , ellipseCenter.z ) ;
    Vector3 point = Vector3 . ProjectOnPlane ( transform.position , transform.up ) ;
    Vector2 point2D = new Vector2 ( point.x , point.z ) ;
    Vector3 feetAxis - Vector3 . ProjectOnPlane ( ( rightFootTarget.position leftFootTarget.position ) , transform.up ) . normalized ;
    Vector2 feetAxis 2D = new Vector2 ( feetAxis.x , feetAxis.z ) ;
    Vector2 pointRotated Rotate2D ( point 20 , GetAngle2D ( feetAxis 2D , Vector2.right ) ) ;
    return IsInEllipse ( pointRotated , ellipseCenter 20 , balancingMinorRadius , balancingMajor Radius ) ;


 */