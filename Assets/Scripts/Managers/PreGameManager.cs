using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using RTLTMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PreGameManager : MonoBehaviour
{
    [Header("PlayerPrefs")] 
    public float topScore;
    public float topScore2;
    public float sumScore;
    
    [Header("Values")]
    public Image image;
    public Sprite[] textures;
    public int numberOfSelectedGame;
    public bool isLearned;
    
    [Header("Objects")] 
    public RTLTextMeshPro[] gameDetailObjects;
    private string _url;
    public GameObject gamePlayPage;
    public GameObject[] gamePages;
    public GameObject tutorialPage;

    private void Awake()
    {
        var a = PlayerPrefs.GetInt("sound");
        isLearned = a == 0;

        topScore = PlayerPrefs.GetFloat("topScore");
        sumScore = PlayerPrefs.GetFloat("sumScore");
    }
    public void ChangeLearn()
    {
        isLearned = !isLearned;
    }

    private string _jsonString;
    public void SelectGame(int number)
    {
        var dataAsJson = Resources.Load("GameDetails");
        var reader = dataAsJson.ToString();
        
        numberOfSelectedGame = number;
        var details = JsonUtility.FromJson<Details>(reader);

        gameDetailObjects[0].text = details.objectDetails[number].name;
        gameDetailObjects[1].text = details.objectDetails[number].s1;
        gameDetailObjects[2].text = details.objectDetails[number].s2;
        _url = details.objectDetails[number].link;
        image.sprite = textures[number];
    }
    public void OpenMoreDescription()
    {
        Application.OpenURL(_url);
    }

    public void StartGame()
    {
        if (isLearned)
        {
            StartCoroutine(StartSchedule());
        }
        else
        {
            Debug.Log("Not learned still");
        }
    }
    private IEnumerator StartSchedule()
    {
        yield return new WaitForSeconds(1);
        tutorialPage.SetActive(true);
    }
    public void StartGamePlay()
    {
        StartCoroutine(StartScheduleGamePlay());
    }
    private IEnumerator StartScheduleGamePlay()
    {
        yield return new WaitForSeconds(0.5f);
        //gamePlayPage.SetActive(true);
        if (numberOfSelectedGame == 0)
        {
            gamePages[0].SetActive(true);
        }
        else
        {
            gamePages[1].SetActive(true);
        }
    }

    public void OpenEndLink()
    {
        Application.OpenURL("http://mfaxyz.ir/");
    }
}
