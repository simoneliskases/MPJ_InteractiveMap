using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor
{
    private BezierCurve _curve;
    private Transform _handleTransform;
    private Quaternion _handleRotation;

    private const int lineSteps = 10;

    private void OnSceneGUI()
    {
        _curve = target as BezierCurve;
        _handleTransform = _curve.transform;

        if(Tools.pivotRotation == PivotRotation.Local)
        {
            _handleRotation = _handleTransform.rotation;
        }
        else
        {
            _handleRotation = Quaternion.identity;
        }

        Vector3 _p0 = ShowPoint(0);
        Vector3 _p1 = ShowPoint(1);
        Vector3 _p2 = ShowPoint(2);
        Vector3 _p3 = ShowPoint(3);

        Handles.color = Color.gray;
        Handles.DrawLine(_p0, _p1);
        Handles.DrawLine(_p1, _p2);

        Handles.color = Color.white;
        Vector3 _lineStart = _curve.GetPoint(0f);

        for (int i = 1; i <= lineSteps; i++)
        {
            Vector3 _lineEnd = _curve.GetPoint(i / (float)lineSteps);
            Handles.DrawLine(_lineStart, _lineEnd);
            _lineStart = _lineEnd;
        }
    }

    private Vector3 ShowPoint(int _index)
    {
        Vector3 _point = _handleTransform.TransformPoint(_curve.points[_index].position);
        EditorGUI.BeginChangeCheck();
        _point = Handles.DoPositionHandle(_point, _handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_curve, "Move Point");
            EditorUtility.SetDirty(_curve);
            _curve.points[_index].position = _handleTransform.InverseTransformPoint(_point);
        }

        return _point;
    }
}
