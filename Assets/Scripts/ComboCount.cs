using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
    [SerializeField] private Bird player;
    [SerializeField] private TextMeshProUGUI comboText;
    public Color flashColor;

    private void Start()
    {
        player.onComboChanged += UpdateComboText;
    }

    private void Update() {
        comboText.color = Color.Lerp(comboText.color, Color.white, Time.deltaTime * 1.25f);
    }

    private void UpdateComboText(int newCombo)
    {
        comboText.text = $"X{newCombo}";
        comboText.color = flashColor;
    }
}