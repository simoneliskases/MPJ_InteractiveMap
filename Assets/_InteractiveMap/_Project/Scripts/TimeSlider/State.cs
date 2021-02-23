using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected TimeSlider TimeSlider;

    public State(TimeSlider _timeSlider)
    {
        TimeSlider = _timeSlider;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Slide()
    {
        yield break;
    }
}
