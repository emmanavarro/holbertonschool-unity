
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float minutes, seconds, milliseconds, internTime;

    // Update is called once per frame
    void Update()
    {
        internTime += Time.deltaTime;
        minutes = (int)(internTime / 60f);
        seconds = (int)(internTime % 60f);
        milliseconds = (int)(internTime * 100) % 100;
        TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
    }
}
