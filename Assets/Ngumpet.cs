using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ngumpet : MonoBehaviour
{
    [SerializeField]
    GameObject buka, tutup, Player, anak;

    // Start is called before the first frame update
    void Start()
    {
        buka.SetActive(true);
        tutup.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            buka.SetActive(true);
            tutup.SetActive(false);
            Player.SetActive(true);
            anak.SetActive(true);
            
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.R))
        {
            buka.SetActive(false);
            tutup.SetActive(true);
            Player.SetActive(false);
            anak.SetActive(false);

        }
    }

       



   



}
