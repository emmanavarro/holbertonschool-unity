using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Text timeText;
    public GameObject timerMenu;
    public GameObject menuWin;
    public Text finalText;
    public AudioSource victory;
    public AudioSource cheeryMonday;

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().enabled = false;
            Win();
        }
    }
    public void Win()
    {
        timerMenu.SetActive(false);
        menuWin.SetActive(true);
        finalText.text = timeText.text;
        cheeryMonday.Stop();
        victory.Play();
    }
}