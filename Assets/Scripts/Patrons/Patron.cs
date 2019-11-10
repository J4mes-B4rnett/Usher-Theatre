using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patron : Humanoid
{
     [HideInInspector]
     public Task task;

     private new void Awake()
     {
          base.Awake();
          task = GetComponent<Task>();

          SwitchState(usableStates[States.PatronIdle]);
     }

     protected override void SetupStates()
     {
          usableStates.Add(States.PatronIdle, new UsherIdleState(this, States.PatronIdle.ToString()));
          usableStates.Add(States.PatronLeave, new PatronLeaveState(this, States.PatronLeave.ToString()));
     }
}
