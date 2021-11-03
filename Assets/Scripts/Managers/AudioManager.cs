using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Variables")] 
    public bool sound;
    public bool music;
    
    
    [Header("Components")] 
    public AudioSource[] sources;
    public Image[] images;

    private void Awake()
    {
        var a = PlayerPrefs.GetInt("sound");
        var b = PlayerPrefs.GetInt("music");


        sound = a == 0;
        music = b == 0;
        if (!music)
        {
            images[0].color = new Color(1, 1, 1, 0.5f);
            images[2].color = new Color(1, 1, 1, 0.5f);
        }

        if (!sound)
        {
            images[1].color = new Color(1, 1, 1, 0.5f);
            images[3].color = new Color(1, 1, 1, 0.5f);
        }
        
    }


    public void ChangeSettings(string witch)
    {
        switch (witch)
        {
            case "sound":
                sound = !sound;
                break;
            case "music":
                music = !music;
                break;
        }
        var a = sound ? 0 : 1;
        var b = music ? 0 : 1;
        //Debug.Log(a + "|" + b);
        PlayerPrefs.SetInt("sound", a);
        PlayerPrefs.SetInt("music", b);
        
        if (!music)
        {
            images[0].color = new Color(1, 1, 1, 0.5f);
            images[2].color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            images[0].color = Color.white;
            images[2].color = Color.white;
        }

        if (!sound)
        {
            images[1].color = new Color(1, 1, 1, 0.5f);
            images[3].color = new Color(1, 1, 1, 0.5f);
        }else
        {
            images[1].color = Color.white;
            images[3].color = Color.white;
        }
    }
    public void BtnClickSound(int index)
    {
        if (sound)
        {
            sources[index].Play();
        }
    }
}
