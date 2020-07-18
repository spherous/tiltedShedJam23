using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private HeartSpawner heartSpawner;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.left * speed;
    }

    public void Spawned(HeartSpawner spawner) => heartSpawner = spawner;
    
    public void Fly(float height, float newSpeed)
    {
        transform.position = new Vector3(11f, height, 0f);
        speed = newSpeed;
        body.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bird bird = other.gameObject.GetComponent<Bird>();
        if(bird != null)
        {
            bird.Score();
            heartSpawner.Return(this);
        }
    }
}