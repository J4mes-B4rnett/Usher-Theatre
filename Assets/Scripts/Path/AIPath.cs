using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{
     public Transform[] pathPoints;

     private void OnDrawGizmos()
     {
          Gizmos.color = Color.green;

          for (int i = 0; i < pathPoints.Length; i++)
          {
               Gizmos.DrawWireSphere(pathPoints[i].position, 0.5f);
          }
     }
}
