using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOne : State
{
    public StateOne(TimeSlider _timeSlider) : base(_timeSlider)
    {
    }

    public override IEnumerator Start()
    {
        yield break;
    }

    public override IEnumerator Slide()
    {
        TimeSlider.kniveOne.transform.position = new Vector3(0, TimeSlider.sliderEndValue - TimeSlider.slider.value + TimeSlider.sliderStartValue, 0);
        TimeSlider.kniveTwo.transform.position = new Vector3(0, TimeSlider.slider.value, 0);

        yield return null;
    }
}
