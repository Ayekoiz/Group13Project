using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_Curve : MonoBehaviour
{


    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    [SerializeField] Transform point3;
    [SerializeField] Transform point4;
    // this makes it so the you can see it in editer 
    void OnDrawGizmos()
    {
        for (float i = 0; i < 1; i += 0.05f) {
            Gizmos.DrawSphere(GetVector2(i), 0.05f);
        }
        Gizmos.DrawLine(point1.position, point2.position);
        Gizmos.DrawLine(point2.position, point3.position);
        Gizmos.DrawLine(point3.position, point4.position);

    }
    //the Bezier_Curve it self
    public Vector2 GetVector2(float t)
    {
        return Mathf.Pow(1 - t, 3) * point1.position +
             3 * Mathf.Pow(1 - t, 2) * t * point2.position +
             3 * (1 - t) * Mathf.Pow(t, 2) * point3.position
             + Mathf.Pow(t, 3) * point4.position;
    }
    
}
