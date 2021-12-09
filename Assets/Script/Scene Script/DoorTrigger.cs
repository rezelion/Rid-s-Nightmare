using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController DoorEnabled;
    public int doorNum;
    private bool playermasuk;
    
    private static int doorID;


    //private void Start()
    //{
    //    doorID = doorNum;
    //}
    private void Update()
    {
        if (playermasuk)
        {
            doorID = doorNum;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playermasuk = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playermasuk = false;

        }
    }
}
