using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetected : MonoBehaviour
{
    

    [Header("Attack")]

    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;

    private float canAttack;

    [Header("Health")]
    private float health;

    [SerializeField] private float maxHealth;

    private Transform target;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform posisiAwalMusuh;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    public float kecepatanGerak;
    public bool berbalik;
    Rigidbody2D rb2d;

    void Start()
    {
        health = maxHealth;
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
        GetComponent<SpriteRenderer>().flipX = (transform.position.x < player.position.x);
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
        GetComponent<SpriteRenderer>().flipX = (transform.position.x < posisiAwalMusuh.position.x);
        if (Vector2.Distance(transform.position, posisiAwalMusuh.position) < 1f)
        {
            rb2d.velocity = Vector2.zero;
        }
        else 
        {
            if (transform.position.x < posisiAwalMusuh.position.x)
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<CharacterPlayer>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<CharacterPlayer>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
            
        }   
    }
}
