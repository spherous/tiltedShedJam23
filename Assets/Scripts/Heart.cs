using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float speed;
    public float colorChangeSpeed;
    private int lane;
    private HeartSpawner heartSpawner;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject collectionParticle;
    public Color targetColor;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.left * speed;
        targetColor = spriteRenderer.color;
    }

    private void Update()
    {
        if(spriteRenderer.color != targetColor)
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, Time.deltaTime * colorChangeSpeed);
    }

    public void Spawned(HeartSpawner spawner) => heartSpawner = spawner;
    
    public void Fly(float height, float newSpeed, int newLane)
    {
        lane = newLane;
        transform.position = new Vector3(11f, height, 0f);
        speed = newSpeed;
        body.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bird bird = other.gameObject.GetComponent<Bird>();
        if(bird != null)
        {
            bird.Score(lane);
            Instantiate(collectionParticle, transform.position, Quaternion.identity);
            heartSpawner.Return(this);
        }
    }
}