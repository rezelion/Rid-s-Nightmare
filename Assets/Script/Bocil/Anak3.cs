using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anak3 : Collecteble
{
    public static Anak3 Instance { get; private set; }
    [SerializeField] int AnakValue = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected override  void Collected()
    {
        GameManager.Myinstance.AddAnak(AnakValue);
        gameObject.SetActive(false);
    }
}
