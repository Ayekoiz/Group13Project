using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Jump : MonoBehaviour
{
    float JumpV = 7f;
    float Gravity = 10f;
    Vector2 velocity = Vector2.zero;
	float remainingTime = 0;
    Rigidbody2D rb;
    bool OnGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (remainingTime > 0) {
			remainingTime -= Time.deltaTime;
		}
    }

    public void FixedUpdate()
    {
        OnGround = Physics2D.Raycast(transform.position, -Vector2.up, 0.01f);
        if (!OnGround)
            velocity.y -= Gravity * Time.deltaTime;
        else if (remainingTime <= 0)
        {
            OnGround = false;
            velocity.y = JumpV;
            remainingTime = 5;
        } 
        else
            velocity.y = 0f;

        rb.velocity = velocity;
    }
}
