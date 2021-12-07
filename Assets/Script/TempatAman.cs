using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempatAman : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Myinstance.TempatAman();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIManager.Myinstance.HideKondisiMenang();
        }
    }
}
