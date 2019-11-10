using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Humanoid : MonoBehaviour
{
     public State currentState;

     public Dictionary<States, State> usableStates = new Dictionary<States, State>();
     [HideInInspector]
     public NavMeshAgent NavMeshAgent;

     public virtual void Awake()
     {
          NavMeshAgent = GetComponent<NavMeshAgent>();
          SetupStates();
     }

     public void SwitchState(State state)
     {
          //Call the OnExit function of the current state.
          currentState?.OnStateExit();
          //Change our current state to the state we are swapping to.
          currentState = state;
          //Call the current states OnStateEnter function.
          currentState?.OnStateEnter();

          Debug.Log(currentState.stateName);
     }

     private void Update()
     {
          if (currentState != null)
          {
               currentState.StateUpdate();
          }
     }

     protected abstract void SetupStates();
}
