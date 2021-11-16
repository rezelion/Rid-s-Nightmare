using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Boss : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Boss.isAttacking = true;
        }
    }
     void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            Boss.isAttacking = false;
        }
    }
}
