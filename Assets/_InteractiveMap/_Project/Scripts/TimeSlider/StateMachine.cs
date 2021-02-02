using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State State;

    public void SetState(State _state)
    {
        State = _state;
        StartCoroutine(State.Start());
    }
}
