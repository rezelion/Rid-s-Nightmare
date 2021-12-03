using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController DoorEnabled;

    private void OnTriggerStay2D(Collider2D collision)
    {
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
