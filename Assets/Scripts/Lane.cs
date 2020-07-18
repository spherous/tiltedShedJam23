using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField] private AudioClip laneCollectionCharm;
    [SerializeField] private AudioSource audioSource;

    internal void Chime()
    {
        audioSource.PlayOneShot(laneCollectionCharm);
    }
}
