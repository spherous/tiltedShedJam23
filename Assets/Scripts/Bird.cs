using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private List<AudioClip> flapClips = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;
    public float flapHeight;
    public int score;
    [SerializeField] private List<Transform> lanes = new List<Transform>();
    private int lanePos;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        lanePos = 2;   
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, lanes[lanePos].position, Time.deltaTime * flapHeight);
    }

    internal void Score()
    {
        score++;
    }

    public void Flap(bool up = true)
    {
        lanePos = up 
            ? lanePos - 1 < 0 
                ? 0 : lanePos - 1 
                : lanePos + 1 > lanes.Count -1 
                    ? lanes.Count - 1 : lanePos + 1;
                    
        // body.velocity = up ? Vector2.up * flapHeight : Vector2.down * flapHeight;
        audioSource.PlayOneShot(flapClips[UnityEngine.Random.Range(0, flapClips.Count)]);
    }
}