using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController DoorEnabled;
    bool playermasuk;

    private void Update()
    {
        if(playermasuk)
        {
            Debug.Log("Player Pintu");
            if (Input.GetKeyDown("e"))
            {
                DoorEnabled.OpenDoor();
            }
            if (Input.GetKeyDown("f"))
            {
                DoorEnabled.CloseDoor();
            }
        }
    }
   

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playermasuk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playermasuk = false;
        }
    }

}
