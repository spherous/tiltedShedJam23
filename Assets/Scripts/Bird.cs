using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    public float flapHeight;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();    
    }

    internal void Score()
    {
        Debug.Log("Score!");
    }

    public void Flap()
    {
        body.velocity = Vector2.up * flapHeight;
    }
}