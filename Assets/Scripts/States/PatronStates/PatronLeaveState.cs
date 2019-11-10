using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronLeaveState : State
{
     public PatronLeaveState(Humanoid owner, string stateName) : base(owner, stateName)
     {

     }

     public override void OnStateEnter()
     {
          owner.NavMeshAgent.SetDestination(PatronManager.Instance.patronLeavePoint.position);
     }

     public override void OnStateExit()
     {
          
     }

     public override void StateUpdate()
     {
          float dist = Vector3.Distance(owner.transform.position, PatronManager.Instance.patronLeavePoint.position);

          if (dist <= owner.NavMeshAgent.stoppingDistance)
          {
               owner.SwitchState(owner.usableStates[States.PatronIdle]);
          }
     }
}
