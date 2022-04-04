using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource myAudioFx;
    public AudioClip hoverAudioFx;
    public AudioClip clickAudioFx;

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        PlayerPrefs.SetString("lastSceneLoaded", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    public void HoverSound()
    {
        myAudioFx.PlayOneShot(hoverAudioFx);
    }
    public void ClickSound()
    {
        myAudioFx.PlayOneShot(clickAudioFx);
    }
}
