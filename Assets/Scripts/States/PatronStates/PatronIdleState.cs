using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PatronIdleState : State
{

     public PatronIdleState(Humanoid patron, string stateName) : base(patron, stateName)
     {
          
     }

     public override void OnStateEnter()
     {
          Debug.Log("Patron entered Idle State");
     }

     public override void OnStateExit()
     {
          Debug.Log("Patron Exited Idle State");

          owner.StopAllCoroutines();
     }

     public override void StateUpdate()
     {
          
     }
}
