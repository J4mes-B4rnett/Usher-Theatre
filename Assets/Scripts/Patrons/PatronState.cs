using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PatronState
{
     public Patron patron;
     public string stateName;

     public PatronState(Patron patron, string stateName)
     {
          this.patron = patron;
          this.stateName = stateName;
     }

     public abstract void StateUpdate();

     public abstract void OnStateEnter();

     public abstract void OnStateExit();
}
