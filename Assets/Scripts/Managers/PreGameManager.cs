using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PreGameManager : MonoBehaviour
{
    [Header("PlayerPrefs")] 
    public int topScore;
    public int sumScore;
    
    [Header("Values")]
    public Image image;
    public Sprite[] textures;
    public int numberOfSelectedGame;
    public bool isLearned;
    
    [Header("Objects")] 
    public Text[] gameDetailObjects;
    private string _url;
    public GameObject gamePlayPage;
    public GameObject tutorialPage;

    private void Awake()
    {
        var a = PlayerPrefs.GetInt("sound");
        isLearned = a == 0;

        topScore = PlayerPrefs.GetInt("topScore");
        sumScore = PlayerPrefs.GetInt("sumScore");
    }

    public void ChangeLearn()
    {
        isLearned = !isLearned;
    }
    public void SelectGame(int number)
    {
        var dataAsJson = File.ReadAllText(Application.streamingAssetsPath + "/GameDetails.json");
        numberOfSelectedGame = number;
        var details = JsonUtility.FromJson<Details>(dataAsJson);

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
        gamePlayPage.SetActive(true);
    }
}
