using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> frames = new List<Sprite>();
    private int currentFrame;
    public float framesPerSecond;
    private float nextFrameTime;

    private void Start()
    {
        nextFrameTime = Time.timeSinceLevelLoad + 1/framesPerSecond;    
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad >= nextFrameTime && frames.Count > 0)
        {
            currentFrame = currentFrame == frames.Count - 1 ? 0 : currentFrame + 1;
            spriteRenderer.sprite = frames[currentFrame];
            nextFrameTime = Time.timeSinceLevelLoad + 1 / framesPerSecond;    
        }
    }
}
