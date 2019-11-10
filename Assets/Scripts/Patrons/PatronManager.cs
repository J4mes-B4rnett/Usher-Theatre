using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronManager : MonoBehaviour
{
     public static PatronManager Instance;

     public Transform patronSpawnPoint;
     public Transform patronLeavePoint;
     public Transform patronMoveLocation;
     public Patron patron;
     public int AmountOfPatronsForLevel;
     public float patronSpawnRate;

     private int patronsSpawned;

     private void Awake()
     {
          Instance = this;

          patronsSpawned = 0;
          StartCoroutine(PatronSpawns());
     }

     private IEnumerator PatronSpawns()
     {
          while (true)
          {
               Patron newPatron = Instantiate(patron, patronSpawnPoint.position, Quaternion.identity);
               newPatron.NavMeshAgent.SetDestination(patronMoveLocation.position);
               patronsSpawned++;

               if (patronsSpawned >= AmountOfPatronsForLevel)
               {
                    break;
               }

               yield return new WaitForSeconds(patronSpawnRate);
          }
     }
}
