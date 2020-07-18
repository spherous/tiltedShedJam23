using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();    
    }

    public void Flap()
    {
        
    }
}
