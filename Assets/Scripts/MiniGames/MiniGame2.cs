using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MiniGame2 : MonoBehaviour
{
    [Header("Components")] 
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject[] wavesObjects;
    public Text timerText;
    public AudioManager audioManager;
    public PreGameManager preGameManager;


    [Header("MainTexts")] 
    public RTLTextMeshPro[] buttonTexts;
    public RTLTextMeshPro mainText;
    public string[] fullPoems1;
    public string[] fullPoems2;
    public string[] correctWords1;
    public string[] correctWords2;
    public string[] inCorrectWords1;
    public string[] inCorrectWords2;


    [Header("Values")]
    public float delayToStart;
    public int cycleCounter;
    public int whichSound;
    public float time;
    public int[] cycleTime;
    public bool decreaseTime;
    public bool timeOver;
    public int scoreNumber;
    public int scoreDValue;
    public int trueBox;
    
    [Header("EndObjects")]
    public Text topScore;
    public Text showScore;
    public GameObject endGamePage;
    public GameObject game2Page;

    /*private void FixedUpdate()
    {
        if (time >= 0 && decreaseTime)
        {
            time -= Time.fixedDeltaTime;
            timerText.text = Math.Round(time,1) + "s";
        }
        else if (time <= 0 && !timeOver)
        {
            timeOver = true;
        }
    }
    
    public List<int> listNumbers = new List<int>();

    public void ClickBtn(int whichBtn)
    {
        if (whichBtn == trueBox)
        {
            
        }
        else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        audioManager.sources[0].Play();
        if (preGameManager.topScore2 < scoreNumber)
        {
            PlayerPrefs.SetFloat("topScore2", scoreNumber);
            preGameManager.topScore2 = scoreNumber;
        }
        PlayerPrefs.SetFloat("sumScore",preGameManager.sumScore + scoreNumber);
        preGameManager.sumScore += scoreNumber; 
        
        topScore.text = preGameManager.topScore.ToString(CultureInfo.InvariantCulture);
        showScore.text = scoreNumber.ToString();
        endGamePage.SetActive(true);
        game2Page.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(StartExam());
        for (var i = 0; i < 5; i++)
        {
            do{
                whichSound = Random.Range(0, 5);
            } while (listNumbers.Contains(whichSound));
            listNumbers.Add(whichSound);
        }
    }
    
    private IEnumerator StartExam()
    {
        yield return new WaitForSeconds(0.1f);
        if (cycleCounter < 5)
        {
            audioSource.clip = audioClips[listNumbers[cycleCounter]];
        }
        else
        {
            audioSource.clip = audioClips[listNumbers[cycleCounter] + 5];
        }
        delayToStart = audioSource.clip.length;
        audioSource.Play();
        
        //yield return new WaitForSeconds(delayToStart);
        
        yield return new WaitForSeconds(1);
        
        wavesObjects[0].SetActive(false);
        wavesObjects[1].SetActive(true);
        
        
        var listBoxes = new List<int>();
        for (var i = 0; i < 3; i++)
        {
            int x;
            do{
                x = Random.Range(0, 3);
            } while (listBoxes.Contains(x));
            listBoxes.Add(x);
        }
        yield return new WaitForSeconds(0.1f);
        trueBox = listBoxes[0];
        if (cycleCounter < 5)
        {
            mainText.text = fullPoems1[listNumbers[cycleCounter]];
            buttonTexts[listBoxes[0]].text = correctWords1[listNumbers[cycleCounter]];
            buttonTexts[listBoxes[1]].text = inCorrectWords1[cycleCounter];
            buttonTexts[listBoxes[2]].text = inCorrectWords1[cycleCounter + 1];
        }
        else
        {
            mainText.text = fullPoems2[listNumbers[cycleCounter]];
            buttonTexts[listBoxes[0]].text = correctWords2[listNumbers[cycleCounter]];
            buttonTexts[listBoxes[1]].text = inCorrectWords2[cycleCounter];
            buttonTexts[listBoxes[2]].text = inCorrectWords2[cycleCounter + 1];
        }
        
        cycleCounter++;
    }*/
}
