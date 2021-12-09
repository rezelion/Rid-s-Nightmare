using UnityEngine;

public class LemariTrigger : MonoBehaviour
{
    [SerializeField] private DoorController Enabled;
    //public int doorNum;
    private bool playermasuk;

    //private static int doorID;


    //private void Start()
    //{
    //    doorID = doorNum;
    //}
    private void Update()
    {
        if (playermasuk)
        {
            //doorID = doorNum;
            if (Input.GetKeyDown("e"))
            {
                Enabled.OpenDoor();
            }
            if (Input.GetKeyDown("f"))
            {
                Enabled.CloseDoor();
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
