﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTwo : State
{
    public StateTwo(TimeSlider _timeSlider) : base(_timeSlider)
    {
    }

    public override IEnumerator Start()
    {
        //TimeSlider.previousButton.SetActive(true);
        //TimeSlider.nextButton.SetActive(true);

        yield break;
    }

    public override IEnumerator Slide()
    {
        TimeSlider.kniveTwo.transform.position = new Vector3((TimeSlider.slider.value - TimeSlider.sliderThreshold * 2) * (-1), TimeSlider.kniveTwo.transform.position.y, TimeSlider.kniveTwo.transform.position.z);       

        if (TimeSlider.slider.value < TimeSlider.sliderThreshold)
        {
            TimeSlider.SetState(new StateOne(TimeSlider));
        }

        yield return null;
    }

    public override IEnumerator Previous()
    {
        TimeSlider.StopCoroutine(Slide());
        YieldInstruction _instruction = new WaitForEndOfFrame();

        Vector3 _origin = new Vector3(TimeSlider.sliderThreshold * (-1), TimeSlider.kniveOne.transform.position.y, TimeSlider.kniveOne.transform.position.z);
        Vector3 _destination = new Vector3(TimeSlider.sliderStartValue * (-1), TimeSlider.kniveOne.transform.position.y, TimeSlider.kniveOne.transform.position.z);
        Vector3 _currentPos;

        float _currentLerpTime = 0;
        float _clampLerpTime = 0;

        while (true)
        {
            _currentLerpTime += Time.deltaTime;
            if (_currentLerpTime >= TimeSlider.slideDuration)
            {
                TimeSlider.SetState(new StateOne(TimeSlider));
                break;
            }

            _clampLerpTime = Mathf.Clamp01(_currentLerpTime / TimeSlider.slideDuration);
            _currentPos = Vector3.Lerp(_origin, _destination, TimeSlider.curve.Evaluate(_clampLerpTime));

            TimeSlider.kniveOne.transform.position = _currentPos;
            TimeSlider.slider.value = _currentPos.x * (-1);

            yield return _instruction;
        }
    }

    public override IEnumerator Next()
    {
        TimeSlider.StopCoroutine(Slide());
        YieldInstruction _instruction = new WaitForEndOfFrame();

        Vector3 _origin = TimeSlider.kniveTwo.transform.position;
        Vector3 _destination = new Vector3(TimeSlider.sliderThreshold * (-1), TimeSlider.kniveTwo.transform.position.y, TimeSlider.kniveTwo.transform.position.z);
        Vector3 _currentPos;

        float _currentLerpTime = 0;
        float _clampLerpTime = 0;

        while (true)
        {
            _currentLerpTime += Time.deltaTime;
            if (_currentLerpTime >= TimeSlider.slideDuration)
            {
                TimeSlider.SetState(new StateThree(TimeSlider));
                break;
            }

            _clampLerpTime = Mathf.Clamp01(_currentLerpTime / TimeSlider.slideDuration);
            _currentPos = Vector3.Lerp(_origin, _destination, TimeSlider.curve.Evaluate(_clampLerpTime));

            TimeSlider.kniveTwo.transform.position = _currentPos;

            yield return _instruction;
        }
    }
}
