using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidFollowing : MonoBehaviour
{
    [SerializeField]
    AccelJunpKid lompatAnak;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform posisiAwalAnak;

    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Animator anim;
    public bool isGrouded;
    private float moveInput;
    public Transform groundCheck;
    public LayerMask ground;
    public float groundCheckRadius;

    Vector3 localScale;
    bool isHurt, isDead;
    bool facingRight = true;
    Rigidbody2D rb2d;

    bool isFollowing;

    // waktu game over
    float currentTime1 = 0f;
    float dirX = 2f;

    private float health = 0f;

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

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
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

    private void waktu()
    {
        currentTime1 -= 1 * Time.deltaTime;
        if (currentTime1 <= 0)
        {
            currentTime1 = 0;
            mati();
            moveInput = 0;
        }

    }

   /* void FixedUpdate()
    {


        if (!isDead)
            moveInput = Input.GetAxisRaw("Horizontal") * moveSpeed;

        isGrouded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        if (!isHurt)
            rb2d.velocity = new Vector2(moveInput, rb2d.velocity.y);
    }*/
    void LateUpdate()
    {

        CheckWhereToFace();
    }
    void SetAnimitionState()
    {
        if (dirX == 0)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }
        if (rb2d.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        if (Mathf.Abs(moveInput) == 2 && rb2d.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        if (Mathf.Abs(moveInput) == 4 && rb2d.velocity.y == 0)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
        if (Input.GetKey(KeyCode.DownArrow))
            anim.SetBool("IsCrouch", true);
        else
            anim.SetBool("IsCrouch", false);

        if (rb2d.velocity.y > 0)
            anim.SetBool("IsJumping", true);
        // Pas Jatuh
        if (rb2d.velocity.y < 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);
        }
    }
    void CheckWhereToFace()
    {
        if (moveInput > 0)
            facingRight = true;
        else if (moveInput < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
    public void UpdateHealth(float mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            healthSlider.value = health;
            // Destroy(gameObject);
        }
    }

    private void mati()
    {
        dirX = 0;
        isDead = true;
        anim.SetTrigger("IsDead");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hantu")
        {
            health -= 10;
        }
        if (col.gameObject.tag == "Hantu" && health > 0)
        {
            StartCoroutine("Hurt");
        }
        if (col.gameObject.tag == "Hantu" && health == 0)
        {
            mati();
        }
    }
    
    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        float r = Time.deltaTime / 0.1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }
    IEnumerator Hurt()
    {
        isHurt = true;
        rb2d.velocity = Vector2.zero;
        if (facingRight)
            rb2d.AddForce(new Vector2(-200f, 200f));
        else
            rb2d.AddForce(new Vector2(200F, 200F));
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }
}
