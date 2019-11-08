using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronArgumentState : PatronState
{
     private Renderer meshRenderer;
     private Material originalMaterial;

     public PatronArgumentState(Patron patron, string stateName) : base(patron, stateName)
     {
     }

     public override void OnStateEnter()
     {
          Debug.Log("Patron entered Argument State");

          patron.StartCoroutine(ArgumentDelay());

          meshRenderer = patron.GetComponent<Renderer>();
          originalMaterial = meshRenderer.material;
          meshRenderer.material = patron.argumentMaterial;
     }

     public override void OnStateExit()
     {
          Debug.Log("Patron Exited Argument State");

          meshRenderer.material = originalMaterial;
     }

     public override void StateUpdate()
     {
          
     }

     private IEnumerator ArgumentDelay()
     {
          yield return new WaitForSeconds(5);

          patron.SwitchState(new PatronIdleState(patron, "Idle State"));
     }
}
