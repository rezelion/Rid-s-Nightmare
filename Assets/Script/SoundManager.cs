using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip tutupPintu, jalan, lari, gameOver, waktuHabis;
    static AudioSource audiosrc;
    void Start()
    {
        tutupPintu = Resources.Load<AudioClip>("TutupPintu");
        jalan = Resources.Load<AudioClip>("Jalan");
        gameOver = Resources.Load<AudioClip>("GameOver");
        waktuHabis = Resources.Load<AudioClip>("LoseGame");
        audiosrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playSound (string clip)
    {
        switch (clip)
        {
            case "TutupPintu":
                audiosrc.PlayOneShot(tutupPintu);
                break;
            case "Jalan":
                audiosrc.PlayOneShot(jalan);
                break;
            case "GameOver":
                audiosrc.PlayOneShot(gameOver);
                break;
            case "LoseGame":
                audiosrc.PlayOneShot(waktuHabis);
                break;
        }
    }
}
