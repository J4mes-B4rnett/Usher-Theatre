using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
     public float timeToCompleteTask;
     public float timeTillTaskFailed;
     public float taskCompletedRewardAmount;
     public float taskFailedAmount;

     public bool taskActive;
     public bool taskFailed;

     protected Patron patron;

     public virtual void Awake()
     {
          StartCoroutine(TaskFailTimer());
          patron = GetComponent<Patron>();
     }

     public virtual void OnTaskCompleted()
     {
          TaskManager.Instance.OnTaskCompleted.Invoke();

          Debug.Log("Task Completed!");
     }

     public virtual void OnTaskFailed()
     {
          TaskManager.Instance.OnTaskFailed.Invoke();

          Debug.Log("Task Failed!");
     }

     private IEnumerator TaskFailTimer()
     {
          yield return new WaitForSeconds(timeTillTaskFailed);

          if (!taskActive)
          {
               OnTaskFailed();
               taskFailed = true;
          }
     }
}
