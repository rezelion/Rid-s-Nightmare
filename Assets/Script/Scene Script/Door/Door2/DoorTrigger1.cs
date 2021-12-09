using UnityEngine;

public class DoorTrigger1 : MonoBehaviour
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

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playermasuk = true;
            
        }
    }

}
