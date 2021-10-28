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
    [Header("Values")]
    public Image image;
    public Sprite[] textures;

    [Header("Objects")] 
    public Text[] gameDetailObjects;
    private string _url;
    public GameObject gamePlayPage;

    public void SelectGame(int number)
    {
        var dataAsJson = File.ReadAllText(Application.streamingAssetsPath + "/GameDetails.json");

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
        StartCoroutine(StartSchedule());
    }

    private IEnumerator StartSchedule()
    {
        yield return new WaitForSeconds(4);
        gamePlayPage.SetActive(true);
    }
}
