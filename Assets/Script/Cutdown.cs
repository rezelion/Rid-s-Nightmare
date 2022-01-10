using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cutdown : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverScreen;

    //Animator anim;
    float currentTime1 = 0f;
    public float startingTime1 = 1f;
    [SerializeField] Text cutdown1;
    bool  isDead;

    // Audio
    AudioSource audiosrc;

    void Start()
    {
        gameOverScreen.SetActive(false);
        //anim = GetComponent<Animator>();
        currentTime1 = startingTime1;
        // Audio
        audiosrc = GetComponent<AudioSource>();
    }
    private void Update()
    {
        waktu();
    }

    // Update is called once per frame
    private void waktu()
    {
        currentTime1 -= 1 * Time.deltaTime;
        cutdown1.text = currentTime1.ToString("0");
        if (currentTime1 <= 0)
        {
            mati();
            currentTime1 = 0;
            if (!audiosrc.isPlaying)
                audiosrc.Play();
        }

    }
    public void mati()
    {
        
        //foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        //{
        //    Destroy(o);
        //}
     
        gameOverScreen.SetActive(true);
            isDead = true;
        //anim.SetTrigger("IsDead");
    }
}
