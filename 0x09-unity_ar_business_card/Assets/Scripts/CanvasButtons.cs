using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButtons : MonoBehaviour
{
    public void facebook()
    {
        Application.OpenURL("https://www.facebook.com/people/Bioingenier%C3%ADa-De-Suelos-Jorge-Navarro-Wolff/100014646254361/");
    }
    public void twitter()
    {
        Application.OpenURL("https://twitter.com/jorgehnw");
    }
    public void telegram()
    {
        Application.OpenURL("https://t.me/bioingenieriasuelos");
    }
    public void youtube()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=Z1eU3BhQ7A0");
    }
}
