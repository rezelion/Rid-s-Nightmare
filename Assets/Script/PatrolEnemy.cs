using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
   
    private Rigidbody2D rb;

    public float kecepatanGerak;
    public bool berbalik;


    void Start()
    {
        berbalik = true;
        rb = GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Balik"))
        {
            berbalik = !berbalik;
        }
    }
}
