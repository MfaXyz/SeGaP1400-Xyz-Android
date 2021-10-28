using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MotivationGenerator : MonoBehaviour
{
    [Header("Values")] 
    public string[] motivationTexts;

    [Header("Components")]
    private Text _motivationText;

    private void Awake()
    {
        _motivationText = GetComponent<Text>();
        _motivationText.text = motivationTexts[Random.Range(0, motivationTexts.Length)];
    }
}
