using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemariOpenClose : MonoBehaviour
{
    [SerializeField]
    GameObject LemariTutup1, LemariBuka1;

    void Start()
    {
        // Lemari
        LemariBuka1.SetActive(false);
        LemariTutup1.SetActive(true);
       // Textlemari.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenLemari()
    {
        if (Input.GetKey(KeyCode.R))
        {
            LemariBuka1.SetActive(true);
            LemariTutup1.SetActive(false);

        }
        else
            LemariBuka1.SetActive(false);
        LemariTutup1.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {

            //Textlemari.SetActive(true);
            LemariBuka1.SetActive(true);
            LemariTutup1.SetActive(false);



        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Equals("Player"))
        {
          
            LemariBuka1.SetActive(false);
            LemariTutup1.SetActive(true);
        }
    }
}
