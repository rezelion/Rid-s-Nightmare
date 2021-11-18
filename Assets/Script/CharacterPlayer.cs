using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    
    float dirX, moveSpeed = 2f;
    private float moveInput; 
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    bool isHurt, isDead;
    bool facingRight = true;
    Vector3 localScale;

    public Transform groundCheck;
    public LayerMask ground;
    public float groundCheckRadius;
    public bool isGrouded;

    public int playerJumps;
    public float Jumpforce;
    private int tempPlayerJumps;

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }
    void Update()
    {
      
        if (isGrouded)
        {
            tempPlayerJumps = playerJumps;
        }
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 4f;
        else moveSpeed = 2f;
        SetAnimitionState();



        if (Input.GetKeyDown(KeyCode.Space) && tempPlayerJumps > 0)
        {
            rb.velocity = Vector2.up * Jumpforce;
            tempPlayerJumps--;
        }

    }

    void FixedUpdate()
    {
        if (!isDead)
            moveInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        isGrouded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

        if (!isHurt)
            rb.velocity = new Vector2(moveInput, rb.velocity.y);
    }
     void LateUpdate()
    {
        CheckWhereToFace(); 
    }
    void SetAnimitionState()
    {
        if(dirX == 0)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }
        if(rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        if (Mathf.Abs(moveInput) == 2 && rb.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        if (Mathf.Abs(moveInput) == 4 && rb.velocity.y == 0)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
        if (Input.GetKey(KeyCode.DownArrow))
            anim.SetBool("IsCrouch", true);
        else
            anim.SetBool("IsCrouch", false);
            
        if (rb.velocity.y > 0)
            anim.SetBool("IsJumping", true);

        // Pas Jatuh
       if(rb.velocity.y < 0)
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hantu")
        {
            health -= 10;
        }
        if (col.gameObject.tag == "Hantu" && health > 0)
        {
            anim.SetTrigger("IsHurt");
            StartCoroutine("Hurt");
        }
        else
        {
            dirX = 0;
            isDead = true;
            anim.SetTrigger("IsDead");
        }
    }
  
    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }

    IEnumerator Hurt()
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200F, 200F));
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }
}
