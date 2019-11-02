using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public List<int> probabilities = new List<int>();
    
    NavMeshAgent agent;

    public GameObject rubbish;

    public string[] functions = { "GarbageDrop", "GoToilet", "WhereIsTheBuffet", "WhereIsMyScreen", "WannaArgument" };
    public int[] probabilityRates = { 10, 3, 3, 3, 1 };
    public int maxWaitingTime = 4;
    int currentWaitingTime = 4;
    Vector3 agentDestination;
    GameObject floor;

    void Start(){
         
        ProbabilityOrganizer();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Timer", currentWaitingTime, currentWaitingTime);
        InvokeRepeating("SetAgentDestination", 0, 5);
    }
    void OnCollisionEnter(Collision col)
    {
        if(floor == null)
        {
            Debug.Log(col.gameObject.name);
            floor = col.gameObject;
        }
    }

    void SetAgentDestination()
    {
       
        //Throw a random position inside the room based on the floor
        float posX = Random.Range((floor.transform.position.x - (floor.transform.localScale.x / 2)), (floor.transform.position.x + (floor.transform.localScale.x / 2)));
        float posZ = Random.Range((floor.transform.position.z - (floor.transform.localScale.z / 2)), (floor.transform.position.z + (floor.transform.localScale.z / 2)));

        // Set it to the agent as destination
        agentDestination = new Vector3(posX, transform.position.y, posZ);
        agent.SetDestination(agentDestination);

    }

    void ProbabilityOrganizer()
    {
        for(int i = 0; i < functions.Length; i++)
        {
            for(int b = 0;b < probabilityRates[i]; b++)
            {
                probabilities.Add(i);
            }
        }
        foreach(int i in probabilities)
        {
            Debug.Log(i);
        }
    }

    void Timer()
    {
        currentWaitingTime = Random.Range(1, maxWaitingTime + 1);

        int randomActionIndex = Random.Range(0, probabilities.Count);
        Invoke(functions[probabilities[randomActionIndex]], 0);
        
    }
    void GarbageDrop()
    {
        Debug.Log("Garbage has been dropped");
    }
    void GoToilet()
    {
        Debug.Log("Where is the toilet?");
    }
    void WhereIsTheBuffet()
    {
        Debug.Log("Where is the buffet?");
    }
    void WhereIsMyScreen()
    {
        Debug.Log("I have this scne number:. Where can I find it?");
    }
    void WannaArgument()
    {
        Debug.Log("I hate you, bitch!");
    }
}
