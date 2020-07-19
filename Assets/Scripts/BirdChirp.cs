using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdChirp : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    public List<AudioClip> chirps = new List<AudioClip>();

    public float timeBetweenChirps;
    public float nextChirpTime;

    private void Update() {
        if(Time.timeSinceLevelLoad >= nextChirpTime)
        {
            source.PlayOneShot(chirps[Random.Range(0, chirps.Count)]);
            nextChirpTime = Time.timeSinceLevelLoad + timeBetweenChirps;
        }
    }
}
