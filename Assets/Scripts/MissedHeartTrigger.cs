﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedHeartTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource missedNoteSource;
    [SerializeField] private AudioSource lostComboSource;
    [SerializeField] private Bird player;
    [SerializeField] private GameObject particlePrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Heart heart = other.gameObject.GetComponent<Heart>();
        if(heart != null)    
        {
            Instantiate(particlePrefab, other.transform.position, Quaternion.identity);
            heart.targetColor = Color.black;
            missedNoteSource.Play();
            if(player.comboCount / 5f > 1)
                lostComboSource.Play();
            
            player.LoseCombo();
            
            player.LosePoints();
        }
    }
}
