using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class TimeSlider : StateMachine
{
    public GameObject mapOne;
    public GameObject mapTwo;
    public GameObject kniveOne;
    public GameObject kniveTwo;
    public GameObject previousButton;
    public GameObject nextButton;
    public Slider slider;
    public float sliderStartValue;
    public float sliderEndValue;

    private void Awake()
    {
        SetState(new StateOne(this));

        slider.minValue = sliderStartValue;
        slider.maxValue = sliderEndValue;
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

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
