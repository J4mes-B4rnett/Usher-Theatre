using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
     public static TaskManager Instance;

     [HideInInspector]
     public UnityEvent OnTaskCompleted;
     [HideInInspector]
     public UnityEvent OnTaskFailed;

     private void Awake()
     {
          Instance = this;

          OnTaskCompleted.AddListener(TaskCompleted);
          OnTaskFailed.AddListener(TaskFailed);
     }

     private void TaskCompleted()
     {
          Debug.Log("Task Completed!");
     }

     private void TaskFailed()
     {
          Debug.Log("Task Failed!");
     }


}
