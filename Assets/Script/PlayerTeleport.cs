using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleport;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<Teleport>().GetDistanitaon().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleport = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
             
        }
    }
}
