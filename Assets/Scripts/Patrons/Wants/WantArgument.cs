using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WantArgument : Wants
{
     public WantArgument(string want, int wantAmount, int wantsUntilAction) : base(want, wantAmount, wantsUntilAction)
     {
     }

     public override void ExecuteWant(Patron patron)
     {
          Collider[] collider = Physics.OverlapSphere(patron.transform.position, 5);

          foreach (var col in collider)
          {
               if (col.gameObject == patron.gameObject)
                    return;

               if (col.CompareTag("Patron"))
               {
                    Patron nearPatron = col.GetComponent<Patron>();

                    if(nearPatron.patronState.GetType() == typeof(PatronIdleState))
                    {
                         PatronIdleState idleState = (PatronIdleState)nearPatron.patronState;

                         foreach (var want in idleState.wants)
                         {
                              if(want.want == this.want)
                              {
                                   if(want.wantAmount >= want.wantsUntilAction)
                                   {
                                        patron.SwitchState(new PatronArgumentState(patron, "Argument State"));
                                        nearPatron.SwitchState(new PatronArgumentState(nearPatron, "Argument State"));
                                   }
                              }
                         }
                    }
               }
          }
     }
}
