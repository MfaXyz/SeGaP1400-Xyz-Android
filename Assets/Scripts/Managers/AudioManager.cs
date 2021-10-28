using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [Header("Variables")] 
    public bool sound;
    public bool music;
    
    
    [Header("Components")] 
    public AudioSource[] sources;

    private void Awake()
    {
        var a = PlayerPrefs.GetInt("sound");
        var b = PlayerPrefs.GetInt("music");

        sound = a == 0;
        music = b == 0;
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
    }
    public void BtnClickSound(int index)
    {
        if (sound)
        {
            sources[index].Play();
        }
    }
}
