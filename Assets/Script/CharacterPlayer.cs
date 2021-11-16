using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 2f;
    private float healthPoint = 100;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    bool isHurting, isDead;
    bool facingRight = true;
    Vector3 localScale;

    void Start()
    {
        healthPoint = maxHealth;
        healthSlider.maxValue = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 300f);
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 4f;
        else moveSpeed = 2f;
        SetAnimitionState();
        if (!isDead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    
    void FixedUpdate()
    {
        if (!isHurting)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
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
        if (Mathf.Abs(dirX) == 2 && rb.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        if (Mathf.Abs(dirX) == 4 && rb.velocity.y == 0)
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
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
    public void UpdateHealth(float mod)
    {
        healthPoint += mod;
        if (healthPoint > maxHealth)
        {
            healthPoint = maxHealth;
        }
        else if (healthPoint <= 0f)
        {
            healthPoint = 0f;
            healthSlider.value = healthPoint;

           

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals ("Banaspati"))
        {
            healthPoint -= 10;
        }
        if(col.gameObject.name.Equals("Banaspati") && healthPoint > 0)
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
        healthSlider.value = Mathf.Lerp(healthSlider.value, healthPoint, t);
    }
   
    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }
}
