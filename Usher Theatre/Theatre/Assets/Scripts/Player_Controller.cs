using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Controller : MonoBehaviour
{
    public Camera cam; 
    NavMeshAgent agent;
    public GameObject ring;

    public float waitTick = 0f;
    public float randomTick = 0f;

    public bool playerSelected = false;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        randomTick = getRandomFloat(5f, 10f);
        waitTick = 0f;

        transform.position = new Vector3(getRandomFloat(-2.5f, 4.1f), getRandomFloat(0f, 0f), getRandomFloat(4f, -14f));
    }

    public float getRandomFloat(float range1, float range2){
        return Random.Range(range1, range2);;
    }

    public Vector3 getRandomPosition(){
       return new Vector3(getRandomFloat(-2.5f, 4.1f), getRandomFloat(0f, 0f), getRandomFloat(4f, -14f));
    }

    void Update(){
        waitTick += Time.deltaTime;

        if (waitTick >= randomTick){
            agent.SetDestination(getRandomPosition());

            waitTick = 0f;
            randomTick = getRandomFloat(5f,10f);
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            waitTick = 0f;

            if (Physics.Raycast(ray, out hit)){
                
                if (hit.collider.tag == "Floor"){
                    Instantiate(ring, hit.point, Quaternion.identity);
                    agent.SetDestination(hit.point);
                    playerSelected = false;
                } 

                if (hit.collider.tag == "Player"){
                    playerSelected = true;
                } 
                Debug.Log("Move to Floor");
                

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
