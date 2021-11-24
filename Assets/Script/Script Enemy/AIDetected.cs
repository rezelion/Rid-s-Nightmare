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
    float agroRange;

    [SerializeField]
    float moveSpeed;

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
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
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
