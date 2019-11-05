using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Transform cam;

    void Awake(){
        cam = Camera.main.transform;
    }

    void Update()
    {
          transform.LookAt(transform.position + cam.rotation * Vector3.back, cam.rotation * Vector3.up);
    }
}
