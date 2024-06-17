using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdjudicatorState
{
    protected AdjudicatorController adjudicator; //Protected means it's going to be available in other states classes.
    public AdjudicatorState(AdjudicatorController adjudicator) //Create new instances of the enemy state and have context of enemy we're switching to. Concrete state.
    {
        this.adjudicator = adjudicator;
    }
    public abstract void OnStateEnter();

    public abstract void OnStateUpdate();

    public abstract void OnStateExit();
}
