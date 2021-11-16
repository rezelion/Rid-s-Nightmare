﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float dirX;
    [SerializeField]
    float moveSpeed = 3f;
    Rigidbody2D rb;
    bool facingRight = false;
    //bool facingRight = false;
    Vector3 localScale;
    public static bool isAttacking = false;
    Animator anim;

     void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        anim = GetComponent<Animator>();
    }
     void Update()
    {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x > 9f)
            dirX = -1f;
        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
        
    }
     void FixedUpdate()
    {
        if (!isAttacking)
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
        
    }
     void LateUpdate()
    {
        CheckYo();
    }
    void CheckYo()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }


}
