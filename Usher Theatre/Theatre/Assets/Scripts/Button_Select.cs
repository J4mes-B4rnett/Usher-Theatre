using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Button_Select : MonoBehaviour
{

    public GameObject FadeInPanel;
    public GameObject FadeOutPanel;

    public AudioSource click;

    public float timeSince = 0f;
    public bool waitFade = false;

    void Start()
    {
        FadeInPanel.SetActive(true);
    }

    void Update()
    {
        timeSince += Time.deltaTime;

        if (timeSince >= 1f){
            FadeInPanel.SetActive(false);
        }

        if (waitFade){
            if (timeSince >= 1.5f){
                SceneManager.LoadScene("Options Menu");
            }
        }
    }

    public void fadeOut(){
        timeSince = 0f;
        FadeOutPanel.SetActive(true);
        waitFade = true;
        click.Play();
    }
}
