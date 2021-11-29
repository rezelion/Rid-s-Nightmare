using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AccelJunpKid : MonoBehaviour
{
    public Action<AccelJunpKid> onHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hantu")
        {
            onHit?.Invoke(this);
        }
    }
}
