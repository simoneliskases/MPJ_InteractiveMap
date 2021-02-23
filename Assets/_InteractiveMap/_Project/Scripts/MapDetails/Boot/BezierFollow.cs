using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    public Transform[] routes;
    [Range(0, 1)]
    public float speedModifier;
    

    private bool _coroutineAllowed;
    private int _routeToGo;
    private float _tParam;
    private Vector3 _objectPosition;
    private Vector3 _objectRotation;

    private void Start()
    {
        _routeToGo = 0;
        _tParam = 0f;
        _coroutineAllowed = true;
    }

    private void Update()
    {
        if (_coroutineAllowed)
        {
            StartCoroutine(FollowRoute(_routeToGo));
        }
    }

    public IEnumerator FollowRoute(int _routeNumber)
    {
        YieldInstruction _instruction = new WaitForEndOfFrame();
        _coroutineAllowed = false;

        List<Vector3> _pointPositions = new List<Vector3>();
        List<Vector3> _pointRotations = new List<Vector3>();

        for (int i = 0; i < routes.Length; i++)
        {
            _pointPositions.Add(routes[_routeNumber].parent.GetChild(i).position);
            _pointRotations.Add(routes[_routeNumber].parent.GetChild(i).eulerAngles);
        }
        
        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * speedModifier;

            _objectPosition = Mathf.Pow(1 - _tParam, 3) * _pointPositions[0] +
                3 * Mathf.Pow(1 - _tParam, 2) * _tParam * _pointPositions[1] +
                3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * _pointPositions[2] +
                Mathf.Pow(_tParam, 3) * _pointPositions[3];

            _objectRotation = Mathf.Pow(1 - _tParam, 3) * _pointRotations[0] +
                3 * Mathf.Pow(1 - _tParam, 2) * _tParam * _pointRotations[1] +
                3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * _pointRotations[2] +
                Mathf.Pow(_tParam, 3) * Mathf.Pow(_tParam, 2) * _pointRotations[2];

            transform.position = _objectPosition;
            transform.rotation = Quaternion.Euler(_objectRotation);

            yield return _instruction;
        }

        _tParam = 0f;
        _routeToGo += 1;

        if (_routeToGo > routes.Length - 1)
        {
            _routeToGo = 0;
        }

        _coroutineAllowed = true;
    }
}
