using UnityEngine;

public class CameraFollow: MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float sinceStart = 0f;
    public GameObject backingCanvas;

    void Start(){
        backingCanvas.SetActive(true);
    }

    void Update(){
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        transform.LookAt(target);
        sinceStart += Time.deltaTime;

        if (sinceStart >= 1.5f){
            backingCanvas.SetActive(false);
        }
    }
}