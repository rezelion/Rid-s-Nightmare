using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzel : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, ClosedSafe, OpenedSafe, Kebuka, pintuKebuka;
    public static bool isSafeOpened = false;
    void Start()
    {
        codePanel.SetActive(false);
        ClosedSafe.SetActive(true);
        OpenedSafe.SetActive(false);
        Kebuka.SetActive(false);
        pintuKebuka.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Puzzel
        if (isSafeOpened)
        {
            codePanel.SetActive(false);
            ClosedSafe.SetActive(false);
            OpenedSafe.SetActive(true);
            Kebuka.SetActive(true);
            pintuKebuka.SetActive(true);

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {




        if (col.gameObject.name.Equals("Player") && !isSafeOpened)
        {
            codePanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            codePanel.SetActive(false);
        }

    }
}
