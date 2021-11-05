using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePage : MonoBehaviour
{
    public MiniGame1 miniGame1;
    public GameObject[] gamesObjects;
    //public GameObject[] tutorialObject;
    //public GameObject[] endObject;
    public void PauseBtn()
    {
        Time.timeScale = 0;
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1;
    }

    public void GoToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gamesObjects[0].SetActive(false);
    }
}
