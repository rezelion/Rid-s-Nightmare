using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anak2 : Collecteble
{
    [SerializeField] int AnakValue = 1;
    protected override  void Collected()
    {
        GameManager.Myinstance.AddAnak(AnakValue);
        Destroy(this.gameObject);   
    }
}
