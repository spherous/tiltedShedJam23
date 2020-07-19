using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
    [SerializeField] private Bird player;
    [SerializeField] private TextMeshProUGUI comboText;

    private void Start()
    {
        player.onComboChanged += UpdateComboText;
    }

    private void UpdateComboText(int newCombo)
    {
        comboText.text = $"X{newCombo}";
    }
}