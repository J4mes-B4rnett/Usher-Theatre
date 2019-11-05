using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PatronIdleState : PatronState
{
     public List<Wants> wants = new List<Wants>();

     public PatronIdleState(Patron patron, string stateName) : base(patron, stateName)
     {
          wants.Add(new WantArgument("Argument", 0, 2));
     }

     public override void OnStateEnter()
     {
          Debug.Log("Patron entered Idle State");

          patron.StartCoroutine(StateDelay());
     }

     public override void OnStateExit()
     {
          Debug.Log("Patron Exited Idle State");

          patron.StopAllCoroutines();
     }

     public override void StateUpdate()
     {
          
     }

     private IEnumerator StateDelay()
     {
          while (true)
          {
               yield return new WaitForSeconds(1);
               IncreaseWants();
          }
     }

     private void IncreaseWants()
     {
          int count = wants.Count;
          int index = Random.Range(0, count);
          Wants want = wants[index];
          want.wantAmount++;

          if(want.wantAmount >= want.wantsUntilAction)
          {
               want.ExecuteWant(patron);
          }
     }
}
