using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

    public Image moodIcon;
    public GameObject moodIconObj;

    public Sprite angry;
    public Sprite question;

    public bool actionInProgress = false;

    void Start(){
         
        ProbabilityOrganizer();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Timer", currentWaitingTime, currentWaitingTime);
        InvokeRepeating("SetAgentDestination", 0, 5);
        moodIconObj.SetActive(false);
    }

    void Update(){
        if (actionInProgress){
            moodIconObj.SetActive(true);
        }
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
        actionInProgress = true;
        Debug.Log("*Drops Trash");
        moodIcon.sprite = angry;
    }
    void GoToilet()
    {
        actionInProgress = true;
        Debug.Log("Where is the toilet?");
        moodIcon.sprite = question;
    }
    void WhereIsTheBuffet()
    {
        actionInProgress = true;
        Debug.Log("Where is the buffet?");
        moodIcon.sprite = question;
    }
    void WhereIsMyScreen()
    {
        actionInProgress = true;
        Debug.Log("I have this screen number. Where can I find it?");
        moodIcon.sprite = question;
    }
    void WannaArgument()
    {
        actionInProgress = true;
        Debug.Log("I hate you!");
        moodIcon.sprite = angry;
    }
}
