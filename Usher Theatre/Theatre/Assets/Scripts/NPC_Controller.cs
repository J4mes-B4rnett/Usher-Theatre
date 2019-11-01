using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public bool inAction = false;

    public float randomActionTick = 0f;
    public float randomMovementTick = 0f;
    public float actionTicks = 0f;
    public float movementTicks = 0f;

    public List<int> probabilities = new List<int>();
    public int RubbishDropRange = 5;
    public int QuestionRange = 4;
    public int ArgumentRange = 1;
    
    NavMeshAgent agent;

    public GameObject rubbish;

    //Action List
    // 1 - Rubbish Drop
    // 2 - Question
    // 3 - Argument

    public float getRandomFloat(float range1, float range2){
        return Random.Range(range1, range2);;
    }

    public Vector3 getRandomPosition(){
       return new Vector3(getRandomFloat(-3f, 25.25f), getRandomFloat(0f, 0f), getRandomFloat(3f, -40f));
    }

    void Start(){
        agent = GetComponent<NavMeshAgent>();

        randomMovementTick = Random.Range(5f, 10f);
        movementTicks = 0f;

        randomActionTick = Random.Range(20f, 30f);
        actionTicks = 0f;

        for (int i = 0; i < RubbishDropRange; i++){
            probabilities.Add(1);
        }
        for (int i = 0; i < QuestionRange; i++){
            probabilities.Add(2);
        }
        for (int i = 0; i < ArgumentRange; i++){
            probabilities.Add(3);
        }
    }
    

    void Update()
    {
        movementTicks += Time.deltaTime;
        actionTicks += Time.deltaTime;
        if (actionTicks >= randomActionTick){
            actionTicks = 0f;
            randomActionTick = Random.Range(20f, 30f);
            int i = Random.Range(0, probabilities.Count);

            switch (probabilities[i])
            {
                case 1:
                    Debug.Log("Drop Rubbish");
                    Vector3 spawnPosition = transform.position;
                    spawnPosition.y -= 1f;
                    Instantiate(rubbish, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Debug.Log("Question");
                    break;
                case 3:
                    Debug.Log("Argument");
                    break;
            }
        }

        if (movementTicks > randomMovementTick){
            movementTicks = 0f;
            randomMovementTick = Random.Range(5f, 10f);

            agent.SetDestination(getRandomPosition());
        }
    }
}
