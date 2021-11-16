using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 5f;
    int healthPoint = 3;
    bool isHurt, isDead;
    bool facingRight = true;
    Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 600f);
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 10f;
        else moveSpeed = 5f;
        SetAnimitionState();
        if (!isDead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        if (!isHurt)
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
        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        if (Mathf.Abs(dirX) == 10 && rb.velocity.y == 0)
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
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals ("Fire"))
        {
            healthPoint -= 1;
        }
        if(col.gameObject.name.Equals("Fire") && healthPoint > 0)
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
    IEnumerator Hurt()
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200F, 200F));
        yield return new WaitForSeconds(0.5f);
    }
}
