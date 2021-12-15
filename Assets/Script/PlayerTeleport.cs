using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleport;
    [SerializeField] GameObject woi;

    private void Start()
    {
        woi.SetActive(false);
    }
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
            woi.SetActive(true);
            currentTeleport = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleport)
            {
                woi.SetActive(false);
                currentTeleport = null;
            }
             
        }
    }
}
