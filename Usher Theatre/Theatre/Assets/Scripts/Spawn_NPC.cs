using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_NPC : MonoBehaviour
{
    public GameObject NPC;

    public float getRandomFloat(float range1, float range2){
        return Random.Range(range1, range2);
    }

    public Vector3 getRandomPosition(){
       return new Vector3(getRandomFloat(-3f, 25.25f), getRandomFloat(0f, 0f), getRandomFloat(3f, -40f));
    }
    
    void Start()
    {
        for (int i = 0; i < 10; i++){
            Instantiate(NPC, getRandomPosition(), Quaternion.identity);
        }   
    }
}
