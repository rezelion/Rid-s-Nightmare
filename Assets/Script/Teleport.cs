﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public Transform GetDistanitaon()
    {
        return destination;
    }
}
