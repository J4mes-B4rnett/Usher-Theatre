using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Camera cam;

    void Awake(){
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 targetVector = this.transform.position - cam.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, cam.transform.rotation * Vector3.up);
    }
}
