using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ngumpet : MonoBehaviour
{
    [SerializeField]
    GameObject buka, tutup, Player, anak;
    bool playerngumpet;

    // Start is called before the first frame update
    void Start()
    {
        buka.SetActive(true);
        tutup.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (playerngumpet)
        {
            Debug.Log("Player Pintu");
            if (Input.GetKey(KeyCode.R))
            {
                buka.SetActive(false);
                tutup.SetActive(true);
                Player.SetActive(false);
                anak.SetActive(false);
            }
            if (Input.GetKey(KeyCode.E))
            {
                buka.SetActive(true);
                tutup.SetActive(false);
                Player.SetActive(true);
                anak.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playerngumpet = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerngumpet = false;
        }
    }









}
