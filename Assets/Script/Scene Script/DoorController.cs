using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject DoorCollider;
    
    public void OpenDoor()
    {
        DoorCollider.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.SetActive(false);
    }
    public void CloseDoor()
    {
        DoorCollider.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.SetActive(true);
    }
}
