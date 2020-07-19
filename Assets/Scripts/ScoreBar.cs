using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private Image scoreBar;
    [SerializeField] private Bird player;
    [SerializeField] private GameObject nopeScreen;
    private int lastScore;
    
    private void Start() {
        scoreBar.fillAmount = .5f;
        player.onScoreChanged += UpdateScoreBar;
        nopeScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void UpdateScoreBar(int newScore)
    {
        if(newScore > lastScore)
        {
            float changeAmount = .01f * Mathf.Floor(player.comboCount / 5f);
            scoreBar.fillAmount = scoreBar.fillAmount + changeAmount > 1f ? 1f : scoreBar.fillAmount + changeAmount;
        }
        if(newScore < lastScore)
            scoreBar.fillAmount = scoreBar.fillAmount - .1f <= 0 ? 0 : scoreBar.fillAmount - .1f;
        
        // Lose
        if(scoreBar.fillAmount <= 0)
        {
            Time.timeScale = 0f;
            nopeScreen.SetActive(true);
        }

        lastScore = newScore;
    }
}
