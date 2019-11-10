using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsherDoTaskState : State
{
     private Task task;
     private Usher usher;

     private float progress;

     public UsherDoTaskState(Humanoid owner, string stateName) : base(owner, stateName)
     {
          usher = owner.GetComponent<Usher>();
     }

     public override void OnStateEnter()
     {
          task = usher.currentTask;
          task.taskActive = true;
          progress = 0;
          Debug.Log("Started Security Task");
     }

     public override void OnStateExit()
     {
          
     }

     public override void StateUpdate()
     {
          progress += 1 * Time.deltaTime;

          usher.taskProgressImage.fillAmount = progress / task.timeToCompleteTask;

          if(progress >= task.timeToCompleteTask)
          {
               task.OnTaskCompleted();
               owner.SwitchState(owner.usableStates[States.UsherIdle]);
               usher.taskProgressImage.fillAmount = 0;
          }
     }
}
