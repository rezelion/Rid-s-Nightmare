using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    [Header("Attack")]

    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;

    private float canAttack;

    [Header("Health")]
    private float health;

    [SerializeField] private float maxHealth;

    private Transform target;

    private Rigidbody2D rb;

    public float kecepatanGerak;
    public bool berbalik;
   


    void Start()
    {
        health = maxHealth;

        berbalik = false;
        rb = GetComponent<Rigidbody2D>();
        
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

    private void FixedUpdate()
    {
       
        if (berbalik)
        {
            rb.velocity = new Vector2(kecepatanGerak, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-kecepatanGerak, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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
        if (other.gameObject.tag == "Kid")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<KidFollowing>().UpdateHealth(-attackDamage);
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
        if (other.gameObject.tag == "Kid")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<KidFollowing>().UpdateHealth(-attackDamage);
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

        if (other.gameObject.CompareTag("Balik"))
        {
            berbalik =! berbalik;
        }
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
        if (other.gameObject.tag == "Kid")
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
        if (other.gameObject.tag == "Kid")
        {
            target = null;
        }
    }
}
