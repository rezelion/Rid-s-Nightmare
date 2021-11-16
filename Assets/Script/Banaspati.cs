using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banaspati : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;
    private float health;
    private void FixedUpdate()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(attackDamage <= canAttack)
            {
                other.gameObject.GetComponent<CharacterPlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;  
            }
        }
    }
}
