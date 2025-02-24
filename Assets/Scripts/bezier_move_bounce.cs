using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezier_move_bounce : Bezier_Curve
{
    [SerializeField] Transform movingthing;
    [SerializeField] float speed;
    float time = 0;
    //uses the Bezier_Curve to move the movingthing using a Sin fuction that changes over time.
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        movingthing.position = GetVector2((Mathf.Sin(time*speed)+1.0f)/2.0f);
    }
}
