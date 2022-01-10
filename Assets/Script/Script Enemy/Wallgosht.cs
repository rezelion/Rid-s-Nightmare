using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallgosht : MonoBehaviour
{
    [SerializeField] GameObject Suara;
    void Start()
    {
        Suara.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Suara.SetActive(true);
        }
        if (collision.gameObject.tag == "Hantu")
        {
            Suara.SetActive(false);
        }
    }
 
    void Update()
    {
        
    }
}
