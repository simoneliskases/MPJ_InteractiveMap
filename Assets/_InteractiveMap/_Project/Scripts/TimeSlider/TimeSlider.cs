using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlider : StateMachine
{
    public GameObject knive;
    public GameObject mapOne;
    public GameObject mapTwo;
    public GameObject mapThree;
    public AnimationCurve slideCurve;
    public float slideDuration;

    private void OnEnable()
    {
        SetState(new MapOne(this));
    }
}
