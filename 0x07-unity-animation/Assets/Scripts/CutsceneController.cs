using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator anim;
    public GameObject mainCamera;
    public GameObject timerCanvas;
    public PlayerController scriptPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
            timerCanvas.SetActive(true);
            scriptPlayer.enabled = true;
            mainCamera.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
