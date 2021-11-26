using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidFollowing : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    Transform posisiAwalAnak;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    void ChasePlayer()
    {
        GetComponent<SpriteRenderer>().flipX = (transform.position.x > player.position.x);
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);

        }

        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);

        }
    }
    void StopChasingPlayer()
    {
        GetComponent<SpriteRenderer>().flipX = (transform.position.x > posisiAwalAnak.position.x);
        if (Vector2.Distance(transform.position, posisiAwalAnak.position) < 0.1f)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            if (transform.position.x < posisiAwalAnak.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
            }
        }
    }
}
