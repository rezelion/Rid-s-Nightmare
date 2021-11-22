using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSenter : MonoBehaviour
{
    Animator anim;
    public SpriteRenderer diplayer;
    public SpriteMask diplayer1;
    private float healthSenter = 0f;
    [SerializeField] private float maxHealthSenter = 100f;
    [SerializeField] private Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        diplayer = GetComponent<SpriteRenderer>();
        diplayer1 = GetComponent<SpriteMask>();
        anim = GetComponent<Animator>();
        healthSenter = maxHealthSenter;
        healthSlider.maxValue = maxHealthSenter;

    }

    // Update is called once per frame
    public void UpdateHealthSenter(float mod)
    {
        healthSenter += mod;
        if (healthSenter > maxHealthSenter)
        {
            healthSenter = maxHealthSenter;
        }
        else if (healthSenter <= 0f)
        {
            healthSenter = 0f;
            healthSlider.value = healthSenter;
            // Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("BOX"))
        {
            healthSenter -= 10;
        }
        if (col.gameObject.name.Equals("BOX") && healthSenter < 0)
        {
            diplayer.enabled = false;
            diplayer1.enabled = false;
        }
      

       
    }
    private void OnGUI()
    {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, healthSenter, t);
    }
}
