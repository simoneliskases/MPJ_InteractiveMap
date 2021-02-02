using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapThree : State
{
    public MapThree(TimeSlider _timeSlider) : base(_timeSlider)
    {
    }

    public override IEnumerator Slide()
    {
        yield return null;
    }
}
