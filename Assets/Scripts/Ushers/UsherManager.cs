using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsherManager : MonoBehaviour
{
     public Usher selectedUsher;

     private void Update()
     {
          SelectUsher();
          AssignTaskToUsher();
     }

     private GameObject GetHitObject()
     {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;

          if(Physics.Raycast(ray, out hit))
          {
               return hit.transform.gameObject;
          }

          return null;
     }

     private void SelectUsher()
     {
          if (Input.GetKeyDown(KeyCode.Mouse0))
          {
               GameObject hitObject = GetHitObject();

               Usher usher = hitObject.GetComponent<Usher>();

               if (usher)
               {
                    selectedUsher = usher;
               }
          }
     }

     private void AssignTaskToUsher()
     {
          if (Input.GetKeyDown(KeyCode.Mouse0))
          {
               GameObject hitObject = GetHitObject();

               Patron patron = hitObject.GetComponent<Patron>();

               if (patron)
               {
                    if (selectedUsher)
                    {
                         selectedUsher.AssignTask(patron, patron.task);
                    }
               }
          }
     }
}
