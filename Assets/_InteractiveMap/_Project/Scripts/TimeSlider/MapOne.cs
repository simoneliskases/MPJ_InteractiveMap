using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOne : State
{
    public MapOne(TimeSlider _timeSlider) : base(_timeSlider)
    {
    }

    public override IEnumerator Start()
    {
        TimeSlider.mapOne.SetActive(true);
        //TimeSlider.mapTwo.SetActive(true);
        //TimeSlider.mapThree.SetActive(false);

        TimeSlider.slider.value = TimeSlider.sliderStartValue;

        yield return null;
    }

    public override IEnumerator Slide()
    {
        TimeSlider.knive.transform.position = new Vector3(TimeSlider.slider.value * (-1), TimeSlider.knive.transform.position.y, TimeSlider.knive.transform.position.z);

        yield return null;
    }
}
