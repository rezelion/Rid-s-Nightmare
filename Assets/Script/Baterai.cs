using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Baterai : MonoBehaviour
{
    public SpriteRenderer SenterRenderer;
    public SpriteMask SenterMask;
    private float healthSenter = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {





       
        if (col.gameObject.CompareTag("Player"))
        {
            if(col.gameObject.CompareTag("Battery"))
            {
                Destroy(col.gameObject);
                healthSenter += 20;
                SenterRenderer.enabled = true;
                SenterMask.enabled = true;
            }
        }
    }
}
