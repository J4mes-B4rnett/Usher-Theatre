using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_NPC : MonoBehaviour
{
    public GameObject NPC;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++){
            Instantiate(NPC, transform.position, Quaternion.identity);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
