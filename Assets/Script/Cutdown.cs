using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cutdown : MonoBehaviour
{
    float currentTime1;
    public float startingTime1 = 10f;
    [SerializeField] Text cutdownText;
    void Start()
    {
        currentTime1 = startingTime1;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime1 += 1 * Time.deltaTime;
        cutdownText.text = currentTime1.ToString("0");
        if(currentTime1 >= 0)
        {
            currentTime1 = 0;
        }
    }
}
