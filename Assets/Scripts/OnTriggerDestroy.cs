﻿using UnityEngine;
using System.Collections;

public class OnTriggerDestroy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}