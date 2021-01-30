using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RescueScoreText : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    
    int rescued;
    int toRescue;

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    

    public void SetToRescue( int amountToRescue )
    {
        toRescue = amountToRescue;

        UpdateText();
    }

    public void AddRescued()
    {
        rescued++;

        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = $"{rescued}/{toRescue} rescued";
    }
}
