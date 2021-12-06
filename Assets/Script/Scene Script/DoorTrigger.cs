using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController DoorEnabled;
    private bool playermasuk;
    private void Update()
    {
        if (playermasuk)
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

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playermasuk = true;
        }
    }

}
