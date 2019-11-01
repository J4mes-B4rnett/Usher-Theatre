using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonEvents : MonoBehaviour
{

    public float sinceStart = 0f;

    public bool CreditsWait = false;
    public bool BackWait = false;

    public GameObject FadeOut;
    public GameObject FadeIn;

    public void Credits(){
        CreditsWait = true;
        sinceStart = 0f;
        FadeOut.SetActive(true);
    }
    
    public void Back(){
        BackWait = true;
        sinceStart = 0f;
        FadeOut.SetActive(true);
    }

    void Start(){
        FadeIn.SetActive(true);
    }

    void Update(){
        sinceStart += Time.deltaTime;

        //if (sinceStart >= 1f){
        //    FadeIn.SetActive(false);
        //}

        if (CreditsWait){
            if (sinceStart >= 1.5f){
                FadeOut.SetActive(false);
                SceneManager.LoadScene("Credits");
            }
        }

        if (BackWait){
            if (sinceStart >= 1.5f){
                FadeIn.SetActive(false);
                SceneManager.LoadScene("Title Menu");
            }
        }
    }
}
