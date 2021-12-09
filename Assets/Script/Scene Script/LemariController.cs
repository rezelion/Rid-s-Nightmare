using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemariController : MonoBehaviour
{
    public GameObject Collider;
    public GameObject Isi;

    public void OpenDoor()
    {
        Collider.GetComponent<BoxCollider2D>().enabled = true;
        Isi.SetActive(true);
        gameObject.SetActive(true);
    }
    public void CloseDoor()
    {
        Collider.GetComponent<BoxCollider2D>().enabled = false;
        Isi.SetActive(false);
        gameObject.SetActive(false);
    }
}
