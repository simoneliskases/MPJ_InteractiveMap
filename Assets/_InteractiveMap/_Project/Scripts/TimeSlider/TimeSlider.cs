using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlider : StateMachine
{
    private void OnEnable()
    {
        SetState(new MapOne(this));
    }
}
