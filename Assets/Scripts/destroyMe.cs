using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{

    public float timeSinceStart = 0f;

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart >= 1f){
            Destroy(this.gameObject);
        }
    }
}
