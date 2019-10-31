using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterAnimation : MonoBehaviour
{

    public float sinceStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sinceStart += Time.deltaTime;
        if (sinceStart >= 1f){
            this.gameObject.SetActive(false);
        }
    }
}
