using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public delegate void OnScoreChanged(int newScore);
    public delegate void OnComboChanged(int newCombo);
    public OnComboChanged onComboChanged;
    public OnScoreChanged onScoreChanged;

    [SerializeField] private Rigidbody2D body;
    [SerializeField] private List<AudioClip> flapClips = new List<AudioClip>();
    [SerializeField] private AudioSource flapSource;
    [SerializeField] private AudioSource comboSource;   
    public float flapHeight;
    public int score;
    [SerializeField] private List<Lane> lanes = new List<Lane>();
    private int lanePos;

    public int comboCount {get; private set;}


    private int comboAudioIndex;
    [SerializeField] private List<AudioClip> comboClips = new List<AudioClip>();

    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        lanePos = 2;   
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, lanes[lanePos].transform.position, Time.deltaTime * flapHeight);
    }

    internal void Score(int lane)
    {
        lanes[lane].Chime();
        score += 1 + Mathf.FloorToInt(comboCount / 5f);
        comboCount++;
        if(comboCount % 5 == 0)
        {
            playComboSound();
        }
        onComboChanged?.Invoke(1 + Mathf.FloorToInt(comboCount / 5f));
        onScoreChanged?.Invoke(score);
    }

    public void LosePoints()
    {
        score--;
        onScoreChanged?.Invoke(score);
    }

    private void playComboSound()
    {
        flapSource.PlayOneShot(comboClips[comboAudioIndex]);
        comboAudioIndex = comboAudioIndex + 1 > comboClips.Count - 1 ? 0 : comboAudioIndex + 1;
    }

    public void LoseCombo()
    {
        comboCount = 0;
        comboAudioIndex = 0;
        onComboChanged?.Invoke(1);
    }

    public void Flap(bool up = true)
    {
        lanePos = up 
            ? lanePos - 1 < 0 
                ? 0 : lanePos - 1 
                : lanePos + 1 > lanes.Count -1 
                    ? lanes.Count - 1 : lanePos + 1;

        // body.velocity = up ? Vector2.up * flapHeight : Vector2.down * flapHeight;
        flapSource.PlayOneShot(flapClips[UnityEngine.Random.Range(0, flapClips.Count)]);
    }
}