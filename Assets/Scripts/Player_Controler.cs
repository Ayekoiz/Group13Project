using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    public float movespeed = 10f;
    float movederection = 0f;
    public float JumpV = 10f;
    bool jumpButtion = false;
    public float drag = .4f;
    public float Gravity = 10f;
    public Vector2 vilocity = Vector2.zero;
    bool OnGround = false;

    Rigidbody2D rb = null;
    SPUM_Prefabs animator = null;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<SPUM_Prefabs>();
    }

    //input
    public void Update()
    {
        movederection = Input.GetAxis("Horizontal");
        jumpButtion = 0.4<Input.GetAxis("Jump");
    }
    
    //phisics
    public void FixedUpdate()
    {
        if (Mathf.Abs(vilocity.x)> drag)
        vilocity.x -= drag* Mathf.Sign(vilocity.x);
        else
        vilocity.x = 0f;

        
        if (Physics2D.Raycast(transform.position, -Vector2.up, 0.01F)) OnGround = true; 
        vilocity.x = Mathf.Max(Mathf.Abs(vilocity.x), Mathf.Abs(movederection * movespeed)) *Mathf.Sign(movederection);
        if (!OnGround)
            vilocity.y -= Gravity * Time.deltaTime;
        else if (jumpButtion)
        {
            OnGround = false;
            vilocity.y = JumpV;
        } 
        else
            vilocity.y = 0f;

        rb.velocity = vilocity;
    }

    
}
