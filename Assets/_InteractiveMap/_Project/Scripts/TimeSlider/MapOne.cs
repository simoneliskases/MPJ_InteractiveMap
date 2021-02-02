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
        TimeSlider.mapTwo.SetActive(true);
        TimeSlider.mapThree.SetActive(false);

        TimeSlider.StartCoroutine(Slide());
        yield return null;
    }

    public override IEnumerator Slide()
    {
        YieldInstruction _instruction = new WaitForEndOfFrame();

        Vector3 _origin = TimeSlider.knive.transform.position;
        Vector3 _destination = new Vector3(_origin.x * (-1), _origin.y, _origin.z);
        Vector3 _currentPos;

        float _currentLerpTime = 0;
        float clampLerpTime = 0;

        while (true)
        {
            _currentLerpTime += Time.deltaTime;
            if(_currentLerpTime >= TimeSlider.slideDuration)
            {
                TimeSlider.SetState(new MapTwo(TimeSlider));
                break;
            }

            clampLerpTime = Mathf.Clamp01(_currentLerpTime / TimeSlider.slideDuration);
            _currentPos = Vector3.Lerp(_origin, _destination, TimeSlider.slideCurve.Evaluate(clampLerpTime));

            TimeSlider.knive.transform.position = _currentPos;
            yield return _instruction;
        }
    }
}
