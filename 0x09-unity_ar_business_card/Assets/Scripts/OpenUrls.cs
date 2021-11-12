using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrls : MonoBehaviour
{
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/ayy_emma");
    }
    public void Github()
    {
        Application.OpenURL("https://github.com/emmanavarro");
    }
    public void Email()
    {
        Application.OpenURL("mailto:elnavarro55@gmail.com");
    }
    public void LinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/emmanavarromillan/");
    }
}
