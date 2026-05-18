using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected readonly StateMachine StateMachine;
    protected readonly float MinTimeScaleValue = 0;
    protected readonly float MaxTimeScaleValue = 1;

    public State(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
}
