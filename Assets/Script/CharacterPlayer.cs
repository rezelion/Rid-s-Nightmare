using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPlayer : MonoBehaviour
{
    //singleton
    public static CharacterPlayer Instance { get; private set; }

    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 2f;
    private float moveInput;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    bool isHurt, isDead;
    bool facingRight = false;
    bool kiri = true;
    Vector3 localScale;
    //public Transform groundCheck;
    //public LayerMask ground;
    //public float groundCheckRadius;
    //public bool isGrouded;
    //public int playerJumps;
    //public float Jumpforce;
    //private int tempPlayerJumps;
    // Senter 
    public SpriteRenderer diplayer;
    public SpriteMask diplayer1;
    private float healthSenter = 0f;
    [SerializeField] private float maxHealthSenter = 100f;
    [SerializeField] private Slider SenterSlider;

    // Cutdown waktu
    float currentTime = 0f;
    float startingTime = 2f;

    // double jump
    public float jumpForce;
    private bool isGrouded;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask WhatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;






    private void Start()
    {
        currentTime = startingTime;
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;

        // Senter
        healthSenter = maxHealthSenter;
        SenterSlider.maxValue = maxHealthSenter;


    }
    // Senter
    public void UpdateHealthSenter(float mod)
    {
        healthSenter += mod;
        if (healthSenter > maxHealthSenter)
        {
            healthSenter = maxHealthSenter;
        }
        else if (healthSenter <= 0f)
        {
            healthSenter = 0f;
            SenterSlider.value = healthSenter;
            // Destroy(gameObject);
        }
    }

    void Update()
    {

       if(health == 0)
        {
            mati();
        }

        isGrouded = Physics2D.OverlapCircle(feetpos.position, checkRadius, WhatIsGround);
        //if(moveInput > 0)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);

        //}else if(moveInput < 0)
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //}
        if(isGrouded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if(jumpTimeCounter > 0)
            {
                
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } 
            else
            {
                isJumping = false;
            }
         
          
        }
     
       
        cutdown();
    
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 10f;

        else moveSpeed = 5f;
        SetAnimitionState();




        // Puzzel

        // Komen
        //if (isGrouded)
        //{
        //    tempPlayerJumps = playerJumps;
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && tempPlayerJumps > 0)
        //{
        //    rb.velocity = Vector2.up * Jumpforce;
        //    tempPlayerJumps--;
        //}

        //sentermati();
    }


    private void sentermati()
    {
        if (rb.velocity != Vector2.zero)
        {
            healthSenter -= 10;
        }

    }

    private void cutdown()
    {
        currentTime -= 1;
        moveInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
       
        if (moveInput == 0 * Time.deltaTime)
        {

            currentTime = 1;
        }
        else
            healthSenter -= 2 * Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        if (healthSenter < 0)
        {
            diplayer.enabled = false;
            diplayer1.enabled = false;
        }
    }

   
    


    void FixedUpdate()
    {




        if (!isDead)
        
            moveInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
           

        //isGrouded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        if (!isHurt)
        
            rb.velocity = new Vector2(moveInput, rb.velocity.y);
        
            
    }
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
        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        if (Mathf.Abs(moveInput) == 5 && rb.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        if (Mathf.Abs(moveInput) == 10 && rb.velocity.y == 0)
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
        if (rb.velocity.y < 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);
        }
    }
    void CheckWhereToFace()
    {
        if (moveInput > 0)
            facingRight = false;
        else if (moveInput < 0)
            facingRight = true; 
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
        if (col.gameObject.tag == "Hantu" && health == 0)
        {
            
            mati();
        }

        if (col.gameObject.CompareTag("Battery"))
        {
             Destroy(col.gameObject);
            healthSenter += 20;
            diplayer.enabled = true;
            diplayer1.enabled = true;
        }
    }
    
    public void mati()
    {
       
        dirX = 0;
        isDead = true;
        anim.SetTrigger("IsDead");
    }

    public void woi()
    {
        dirX = 0;
        isDead = false;
        
    }
    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        float r = Time.deltaTime / 0.1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
        SenterSlider.value = Mathf.Lerp(SenterSlider.value, healthSenter, r);
    }

    IEnumerator Hurt()
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
       
        if (kiri)

            rb.AddForce(new Vector2(-400f, 400f) );


        else
           
            rb.AddForce(new Vector2(200f, 200f));
       
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }
}
