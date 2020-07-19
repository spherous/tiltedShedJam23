using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird player;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        player.onScoreChanged += UpdateScore;    
    }

    private void UpdateScore(int newScore)
    {
        text.text = newScore.ToString();
    }
}
