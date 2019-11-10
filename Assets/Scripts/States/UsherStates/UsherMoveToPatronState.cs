using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UsherMoveToPatronState : State
{
     private Usher usher;
     private float stoppingDist;
     private Task patronTask;

     public UsherMoveToPatronState(Humanoid owner, string stateName) : base(owner, stateName)
     {
          usher = owner as Usher;
          stoppingDist = owner.NavMeshAgent.stoppingDistance;
     }

     public override void OnStateEnter()
     {
          owner.NavMeshAgent.isStopped = false;
          owner.NavMeshAgent.SetDestination(usher.currentAssistingPatron.transform.position);
          patronTask = usher.currentAssistingPatron.task;
     }

     public override void OnStateExit()
     {
          owner.NavMeshAgent.isStopped = true;
     }

     public override void StateUpdate()
     {
          if (patronTask.taskFailed)
          {
               owner.SwitchState(owner.usableStates[States.UsherIdle]);
          }

          float dist = Vector3.Distance(owner.transform.position, usher.currentAssistingPatron.transform.position);

          if (dist <= stoppingDist)
          {
               owner.SwitchState(owner.usableStates[States.UsherDoTask]);
          }
     }
}
