using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform destination;

    private void Start()
    {
        
    }

    public Transform GetDistanitaon()
    {
        return destination;
    }
}
