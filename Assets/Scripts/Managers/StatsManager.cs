using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    //[Header("Values")]

    [Header("Components")] 
    public PreGameManager preGameManager;
    public Text[] bestScoreTexts;
    public Text[] speedsTexts;
    public Text[] levelTexts;
    public Image[] barSpeedImages;
    public Text[] memoryTexts;
    public Image[] barMemoryImages;

    public int _speedPercent;
    private float _levelPercent;
    private void Start()
    {
        bestScoreTexts[0].text = preGameManager.topScore + " :ﺯﺎﯿﺘﻣﺍ ﻦﯾﺮﺘﻬﺑ";
        bestScoreTexts[1].text = preGameManager.topScore2 + " :ﺯﺎﯿﺘﻣﺍ ﻦﯾﺮﺘﻬﺑ";

        #region Speed Value
        _speedPercent = (int)preGameManager.topScore;
        _speedPercent = (_speedPercent * 100 / 114);

        var toFloat = (float)_speedPercent / 100;
        foreach (var x in barSpeedImages)
        {
            //Debug.Log(toFloat);
            x.fillAmount = toFloat;
        }
        
        foreach (var x in speedsTexts)
        {
            x.text = _speedPercent.ToString(CultureInfo.InvariantCulture) + "%";
        }
        #endregion

        #region Level
        var y = preGameManager.sumScore / 100;
        var z = new decimal(y);
        var w = Math.Round(z,1);
        _levelPercent = (float)w;

        foreach (var q in levelTexts)
        {
            q.text = _levelPercent.ToString(CultureInfo.InvariantCulture);
        }
        #endregion
    }
}
