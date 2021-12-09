using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Baterai : MonoBehaviour
{
    public static Baterai Instance { get; private set; }
    private float healthSenter = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            batreoff();
        }
    }
    public void batreoff()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.CompareTag("Player"))
        {

            gameObject.SetActive(false);
            healthSenter += 20;
               
            
        }
    }
}
