using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Usher : Humanoid
{
     [HideInInspector]
     public Task currentTask;
     [HideInInspector]
     public Patron currentAssistingPatron;
     public Image taskProgressImage;


     private new void Awake()
     {
          base.Awake();

          SwitchState(usableStates[States.UsherIdle]);
     }

     public void AssignTask(Patron patron, Task task)
     {
          currentTask = task;
          currentAssistingPatron = patron;

          SwitchState(usableStates[States.UsherMove]);
     }

     protected override void SetupStates()
     {
          usableStates.Add(States.UsherIdle, new UsherIdleState(this, States.UsherIdle.ToString()));
          usableStates.Add(States.UsherMove, new UsherMoveToPatronState(this, States.UsherMove.ToString()));
          usableStates.Add(States.UsherDoTask, new UsherDoTaskState(this, States.UsherDoTask.ToString()));
     }
}
