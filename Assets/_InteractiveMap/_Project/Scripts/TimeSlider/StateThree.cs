using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateThree : State
{
    public StateThree(TimeSlider _timeSlider) : base(_timeSlider)
    {
    }

    public override IEnumerator Start()
    {
        //TimeSlider.nextButton.SetActive(false);
        //TimeSlider.previousButton.SetActive(true);

        yield break;
    }

    public override IEnumerator Previous()
    {
        TimeSlider.StopCoroutine(Slide());
        YieldInstruction _instruction = new WaitForEndOfFrame();

        Vector3 _origin = new Vector3(TimeSlider.sliderThreshold * (-1), TimeSlider.kniveTwo.transform.position.y, TimeSlider.kniveTwo.transform.position.z);
        Vector3 _destination = new Vector3(TimeSlider.sliderStartValue * (-1), TimeSlider.kniveTwo.transform.position.y, TimeSlider.kniveTwo.transform.position.z);
        Vector3 _currentPos;

        float _currentLerpTime = 0;
        float _clampLerpTime = 0;

        while (true)
        {
            _currentLerpTime += Time.deltaTime;
            if (_currentLerpTime >= TimeSlider.slideDuration)
            {
                TimeSlider.SetState(new StateTwo(TimeSlider));
                break;
            }

            _clampLerpTime = Mathf.Clamp01(_currentLerpTime / TimeSlider.slideDuration);
            _currentPos = Vector3.Lerp(_origin, _destination, TimeSlider.curve.Evaluate(_clampLerpTime));

            TimeSlider.kniveTwo.transform.position = _currentPos;

            yield return _instruction;
        }
    }
}
