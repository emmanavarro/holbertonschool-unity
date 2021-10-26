﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertedMode;
    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
            invertedMode.isOn = true;
        else
            invertedMode.isOn = false;
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneLoaded"));
    }

    public void Apply()
    {
        if (invertedMode.isOn == true)
            PlayerPrefs.SetInt("invertedY", 1);
        else
            PlayerPrefs.SetInt("invertedY", 0);
        Back();
    }
}
