using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Controller : MonoBehaviour
{
    public Camera cam; 
    NavMeshAgent agent;
    public GameObject ring;

    public bool playerSelected = false;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                if (playerSelected == false){
                    if (hit.collider.tag == "Floor"){
                        Instantiate(ring, hit.point, Quaternion.identity);
                        agent.SetDestination(hit.point);
                    } 

                    if (hit.collider.tag == "Player"){
                        playerSelected = true;
                    } 
                    Debug.Log("Move to Floor");
                }

                if (playerSelected){
                    if (hit.collider.tag == "Rubbish"){
                        agent.SetDestination(hit.transform.position);
                        Debug.Log("Move to Rubbish");
                    }
                }
            }
        }
    }
}
