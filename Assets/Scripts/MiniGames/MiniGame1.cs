using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MiniGame1 : MonoBehaviour
{
    [Header("Components")]
    public Image[] imageLights;
    public Sprite[] pictureLights;
    public Text timerText;
    public Text scoreText;
    public Button[] btns;
    public string[] waveTexts;
    public Text waveText;
    public GameObject[] wavesObj;

    [Header("EndPageV&C")] 
    public PreGameManager preGameManager;
    public Text topScore;
    public Text showScore;
    public GameObject endGamePage;
    public GameObject game1Page;
    
    [Header("Health")]
    public Text healthText;
    public float healthNumber;
    public float firstHealthNumber;
    [Header("HalfTime")]
    public float time;
    public float cacheTime;
    public bool timeOver;
    [Header("Score")]
    public int scoreNumber;
    public int scoreDValues;
    public bool decreaseTime;
    
    [Header("Values")]
    public int waveNumber;
    public int p1Value;
    public int leftRightLights;
    //public int p23Value;
    public int[] cycleTime1;
    public int cycleIndex1;
    

    private void FixedUpdate()
    {
        if (time >= 0 && decreaseTime)
        {
            time -= Time.fixedDeltaTime;
            timerText.text = Math.Round(time,1).ToString(CultureInfo.InvariantCulture)+ "s" + " :ﻥﺎﻣﺯ";
        }
        else if (time <= 0 && !timeOver)
        {
            timeOver = true;
            foreach (var t in btns)
            {
                t.interactable = false;
            }
            switch (waveNumber)
            {
                case 0:
                    GoToHealth(false,true);
                    break;
                case 1:
                    switch (p1Value)
                    {
                        case 1:
                            GoToHealth(false,true);
                            break;
                        case 2:
                            ClickBtn(true);
                            break;
                    }
                    break;
                case 2:
                    GoToHealth(false, false);
                    break;
                case 3:
                    GoToHealth(false, false);
                    break;
            }
        }
    }
    

    private void GoToHealth(bool value, bool type)
    {
        if (healthNumber > 1)
        {
            healthNumber -= 1;
            healthText.text = healthNumber.ToString(CultureInfo.InvariantCulture) + " :ﯽﺘﻣﻼﺳ";
            if (type)
            {
                ClickBtn(value);
            }
            else
            {
                ClickBtn(value);
            }
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (preGameManager.topScore < scoreNumber)
        {
            PlayerPrefs.SetInt("topScore", scoreNumber);
            preGameManager.topScore = scoreNumber;
        }
        PlayerPrefs.SetInt("sumScore",preGameManager.sumScore + scoreNumber);
        
        topScore.text = preGameManager.topScore.ToString();
        showScore.text = scoreNumber.ToString();
        enabled = false;
        endGamePage.SetActive(true);
        game1Page.SetActive(false);
        
    }

    private void OnEnable()
    {
        healthNumber = firstHealthNumber;
        healthText.text = healthNumber.ToString(CultureInfo.InvariantCulture) + " :ﯽﺘﻣﻼﺳ";
        time = cycleTime1[cycleIndex1];
        cycleIndex1++;
        p1Value = 1;
        imageLights[0].sprite = pictureLights[p1Value];
        scoreText.text = "00" + " :ﺯﺎﯿﺘﻣﺍ";
    }

    public void ClickBtn(bool inTime)
    {
        foreach (var t in btns)
        {
            t.interactable = false;
        }
        cacheTime = cycleTime1[cycleIndex1] - time;
        decreaseTime = false;
        StartCoroutine(StartNewLight(inTime));
    }

    public void ClickBtn2(bool leftRight)
    {
        foreach (var t in btns)
        {
            t.interactable = false;
        }
        cacheTime = cycleTime1[cycleIndex1] - time;
        decreaseTime = false;
        StartCoroutine(StartNewLight(leftRight));
    }
    
    private IEnumerator StartNewLight(bool zeroOne)
    {
        switch (waveNumber)
        {
            case 0:
                scoreNumber += scoreDValues;
                break;
            case 1:
                if (p1Value == 2)
                {
                    if (zeroOne)
                    {
                        scoreNumber += scoreDValues;
                    }
                    else
                    {
                        if (healthNumber > 1)
                        {
                            healthNumber -= 1;
                        }
                        else
                        {
                            EndGame();
                        }
                    }
                }
                else
                {
                    scoreNumber += scoreDValues;
                }
                break;
            case 2:
                var x = zeroOne ? 1 : 0;
                if (x == leftRightLights)
                {
                    scoreNumber += scoreDValues;
                }
                else
                {
                    healthNumber -= 1;
                }
                imageLights[1].sprite = pictureLights[0];
                imageLights[2].sprite = pictureLights[1];
                break;
            case 3:
                var y = zeroOne ? 0 : 1;
                if (y == leftRightLights)
                {
                    scoreNumber += scoreDValues;
                }
                else
                {
                    healthNumber -= 1;
                }
                imageLights[1].sprite = pictureLights[0];
                imageLights[2].sprite = pictureLights[1];
                break;
            case 4:
                
                break;
        }
        healthText.text = healthNumber.ToString(CultureInfo.InvariantCulture) + " :ﯽﺘﻣﻼﺳ";
        scoreText.text = scoreNumber.ToString(CultureInfo.InvariantCulture) + " :ﺯﺎﯿﺘﻣﺍ";
        p1Value = 0;
        foreach (var t in imageLights)
        {
            t.sprite = pictureLights[p1Value];
        }
        

        yield return new WaitForSeconds(Random.Range(1, 3));
        timeOver = false;
        foreach (var t in btns)
        {
            t.interactable = false;
        }

        if (cycleIndex1 < cycleTime1.Length - 1)
        {
            cycleIndex1++;
        }else
        {
            waveNumber++;
            waveText.text = waveTexts[waveNumber];
            cycleIndex1 = 0;
        }

        switch (waveNumber)
        {
            case 0:
                p1Value = 1;
                break;
            case 1:
                p1Value = Random.Range(1, 3);
                break;
            case 2:
                wavesObj[0].SetActive(false);
                wavesObj[1].SetActive(true);
                break;
            case 3:
                wavesObj[0].SetActive(false);
                wavesObj[1].SetActive(true);
                break;
        }
        if (waveNumber == 2 || waveNumber ==3)
        {
            leftRightLights = Random.Range(0, 2);
            if (leftRightLights == 0)
            {
                imageLights[1].sprite = pictureLights[1];
                imageLights[2].sprite = pictureLights[0];
            }
            else
            {
                imageLights[1].sprite = pictureLights[0];
                imageLights[2].sprite = pictureLights[1];
            }
        }
        imageLights[0].sprite = pictureLights[p1Value];
        time = cycleTime1[cycleIndex1];
        decreaseTime = true;
    }
}
