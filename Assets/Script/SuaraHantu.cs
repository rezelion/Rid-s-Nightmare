using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuaraHantu : MonoBehaviour
{
    [SerializeField] public GameObject  Suara;
    // Start is called before the first frame update
    void Start()
    {
        Suara.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Suara.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Suara.SetActive(false);
        }
    }
}
