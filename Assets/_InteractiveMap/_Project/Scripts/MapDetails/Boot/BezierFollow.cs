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

        List<Vector3> _points = new List<Vector3>();

        for (int i = 0; i < routes.Length; i++)
        {
            _points.Add(routes[_routeNumber].parent.GetChild(i).position);
        }

        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * speedModifier;

            _objectPosition = Mathf.Pow(1 - _tParam, 3) * _points[0] +
                3 * Mathf.Pow(1 - _tParam, 2) * _tParam * _points[1] +
                3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * _points[2] +
                Mathf.Pow(_tParam, 3) * _points[3];

            transform.position = _objectPosition;
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
