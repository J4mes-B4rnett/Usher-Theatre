using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controller : MonoBehaviour
{

    public Animator animator;
    public GameObject backing;
    public float sinceStart = 0f;
    public bool waitingPlay = false;
    public bool waitingOptions = false;

    public void Start(){
       animator.SetBool("Fade", false);  
    }

    void Update(){
        sinceStart += Time.deltaTime;

        if (waitingPlay){
            if (sinceStart >= 1.5f){
                SceneManager.LoadScene("TestScene");
            }
        }
        if (waitingOptions){
            if (sinceStart >= 1.5f){
                SceneManager.LoadScene("Options Menu");
            }
        }
    }

    public void Play(){
        backing.SetActive(true);
        sinceStart = 0f;
        waitingPlay = true;
    }

    public void Options(){
        backing.SetActive(true);
        sinceStart = 0f;
        waitingOptions = true;
    }

    public void Quit(){
        Application.Quit();
    }
}
