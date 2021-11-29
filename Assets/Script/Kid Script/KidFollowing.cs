using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidFollowing : MonoBehaviour
{
    [SerializeField]
    AccelJunpKid lompatAnak;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform posisiAwalAnak;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    bool isFollowing;

    public float Jumpforce;
    private void OnEnable()
    {
        lompatAnak.onHit += HandleonHit;
    }

    private void HandleonHit(AccelJunpKid obj)
    {
        if (isFollowing)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Jumpforce);
        }
        
    } 

    private void OnDisable()
    {
        lompatAnak.onHit -= HandleonHit;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        isFollowing = distToPlayer < agroRange;
        if(isFollowing)
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
        if((Vector2.Distance(transform.position, player.position) < 1.3f))
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            if (transform.position.x < player.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            }
        }
        GetComponent<SpriteRenderer>().flipX = (transform.position.x > player.position.x);
    }
    void StopChasingPlayer()
    {
        GetComponent<SpriteRenderer>().flipX = (transform.position.x > posisiAwalAnak.position.x);
        if (Vector2.Distance(transform.position, posisiAwalAnak.position) < 1f)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            if (transform.position.x < posisiAwalAnak.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            }
        }
    }
}
