using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State
{
     public Humanoid owner;
     public string stateName;

     public State(Humanoid owner, string stateName)
     {
          this.owner = owner;
          this.stateName = stateName;
     }

     public abstract void StateUpdate();

     public abstract void OnStateEnter();

     public abstract void OnStateExit();
}
