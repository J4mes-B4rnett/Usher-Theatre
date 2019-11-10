using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityCheckTask : Task
{
     public override void OnTaskCompleted()
     {
          base.OnTaskCompleted();
     }

     public override void OnTaskFailed()
     {
          base.OnTaskFailed();

          patron.SwitchState(patron.usableStates[States.PatronLeave]);
     }
}
