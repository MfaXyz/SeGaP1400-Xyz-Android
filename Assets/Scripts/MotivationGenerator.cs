using System;
using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MotivationGenerator : MonoBehaviour
{
    [Header("Values")] 
    public string[] motivationTexts;
    public int randomValue;

    [Header("Components")]
    private RTLTextMeshPro _motivationText;

    private void Awake()
    {
        randomValue = Random.Range(0, motivationTexts.Length);
        _motivationText = GetComponent<RTLTextMeshPro>();
        _motivationText.text = motivationTexts[randomValue];
    }
}
