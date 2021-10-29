using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Level1")]
    public Sprite[] images1;
    public string[] texts1;
    [Header("Level2")]
    public Sprite[] images2;
    public string[] texts2;
    
    [Header("Components")]
    public PreGameManager preGameManager;
    public Image[] images;
    public Text[] texts;
    public Text slideNumber;
    public int currentSlide;
    public Button[] nextBack;

    private void OnEnable()
    {
        if (preGameManager.numberOfSelectedGame == 0)
        {
            for (var i = 0; i < 3; i++)
            {
                images[i].sprite = images1[i];
                texts[i].text = texts1[i];
            }
        }
        else if (preGameManager.numberOfSelectedGame == 1)
        {
            for (var i = 0; i < 3; i++)
            {
                images[i].sprite = images2[i];
                texts[i].text = texts2[i];
            }
        }
    }

    public void NextBackButtons(int number)
    {
        if (number == 1)
        {
            images[currentSlide].gameObject.SetActive(false);
            texts[currentSlide].gameObject.SetActive(false);
            nextBack[0].interactable = true;
            if (currentSlide < 2)
            {
                currentSlide++;
                slideNumber.text = currentSlide + 1 + "/3";
                images[currentSlide].gameObject.SetActive(true);
                
                texts[currentSlide].gameObject.SetActive(true);
                if (currentSlide == 2)
                {
                    nextBack[1].interactable = false;
                }
            }
        }else if (number == 0)
        {
            images[currentSlide].gameObject.SetActive(false);
            texts[currentSlide].gameObject.SetActive(false);
            nextBack[1].interactable = true;
            if (currentSlide > 0)
            {
                currentSlide--;
                slideNumber.text = currentSlide + 1 + "/3";
                images[currentSlide].gameObject.SetActive(true);
                texts[currentSlide].gameObject.SetActive(true);
                if (currentSlide == 0)
                {
                    nextBack[0].interactable = false;
                }
            }
        }
    }
}
