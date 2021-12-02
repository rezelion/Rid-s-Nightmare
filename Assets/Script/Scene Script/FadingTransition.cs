using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingTransition : MonoBehaviour
{
    public Image imgS;
    public Animator Anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            if (Input.GetKeyDown("w"))
            {
                StartCoroutine(Fading());
            }
        }
    }
    IEnumerator Fading()
    {
        Anim.SetBool("IsFading", true);
        yield return new WaitUntil(() => imgS.color.a == 1);
    }
}
