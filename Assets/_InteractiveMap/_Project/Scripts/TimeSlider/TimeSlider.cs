using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : StateMachine
{
    public GameObject knive;
    public GameObject mapOne;
    public GameObject mapTwo;
    public GameObject mapThree;
    public Slider slider;
    public AnimationCurve slideCurve;
    public float slideDuration;
    public float sliderStartValue;
    public float sliderEndValue;

    private void OnEnable()
    {
        slider.minValue = sliderStartValue;
        slider.maxValue = sliderEndValue;

        SetState(new MapOne(this));
    }

    public void OnValueChanged()
    {
        if(State.Slide() != null)
        {
            StartCoroutine(State.Slide());
        }
    }
}
