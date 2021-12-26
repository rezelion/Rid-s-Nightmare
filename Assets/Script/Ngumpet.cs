using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ngumpet : MonoBehaviour
{
    [SerializeField]
    GameObject buka, tutup, Player, masuk, keluar;
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
                keluar.SetActive(true);
                masuk.SetActive(false);
                
            }
            if (Input.GetKey(KeyCode.E))
            {
                buka.SetActive(true);
                tutup.SetActive(false);
                Player.SetActive(true);
                keluar.SetActive(false);
                masuk.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            playerngumpet = true;
            masuk.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerngumpet = false;
            masuk.SetActive(false);
        }
    }









}
