using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector3 GetPoint (Vector3 _p0, Vector3 _p1, Vector3 _p2, float _t)
    {
        return Vector3.Lerp(Vector3.Lerp(_p0, _p1, _t), Vector3.Lerp(_p1, _p2, _t), _t);
    }
}
