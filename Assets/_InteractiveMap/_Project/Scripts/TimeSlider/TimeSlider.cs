using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : StateMachine
{
    public GameObject mapOne;
    public GameObject mapTwo;
    public GameObject kniveOne;
    public GameObject kniveTwo;
    public GameObject previousButton;
    public GameObject nextButton;
    public Slider slider;
    public float sliderStartValue;
    public float sliderThreshold;
    public float slideDuration;
    public AnimationCurve curve;

    private void OnEnable()
    {
        slider.minValue = sliderStartValue;
        slider.maxValue = sliderStartValue + (sliderThreshold - sliderStartValue) * 2;

        SetState(new StateOne(this));
    }

    private void Start()
    {
        slider.value = sliderStartValue;
    }

    public void OnValueChanged()
    {
        if(State.Slide() != null)
        {
            StartCoroutine(State.Slide());
        }
    }

    public void Next()
    {
        StartCoroutine(State.Next());
    }

    public void Previous()
    {
        StartCoroutine(State.Previous());
    }
}
