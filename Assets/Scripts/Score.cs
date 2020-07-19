using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird player;
    [SerializeField] private TextMeshProUGUI text;
    public Color flashColor;

    private void Awake()
    {
        player.onScoreChanged += UpdateScore;
    }

    private void Update()
    {
        text.color = Color.Lerp(text.color, Color.white, Time.deltaTime * 2f);
    }

    private void UpdateScore(int newScore)
    {
        text.color = flashColor;
        text.text = newScore.ToString();
    }
}
