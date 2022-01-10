using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController DoorEnabled;
    public int doorNum;
    private bool playermasuk;
    public GameObject PintuBuka;



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
                //PintuBuka.SetActive(true);

            }
            if (Input.GetKeyDown("f"))
            {
                DoorEnabled.CloseDoor();
                //PintuBuka.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playermasuk = true;
            PintuBuka.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playermasuk = false;
            PintuBuka.SetActive(false);

        }
    }
}
