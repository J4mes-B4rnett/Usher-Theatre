using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patron : MonoBehaviour
{
     public PatronState patronState;

     public Material argumentMaterial;
     public TextMeshPro stateDebugText;

     private void Awake()
     {
          SwitchState(new PatronIdleState(this, "Idle State"));
     }

     private void Update()
     {
          if(patronState != null)
          {
               patronState.StateUpdate();
          }
     }

     public void SwitchState(PatronState state)
     {
          //Call the OnExit function of the current state.
          patronState?.OnStateExit();
          //Change our current state to the state we are swapping to.
          patronState = state;
          //Call the current states OnStateEnter function.
          patronState?.OnStateEnter();

          stateDebugText.text = patronState.stateName;
          Debug.Log(patronState.stateName);  
     }

     private void OnDrawGizmos()
     {
          Gizmos.DrawWireSphere(transform.position, 5);
     }
}
