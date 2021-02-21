using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform[] points;
    public bool drawGizmos;
    public Color sphereColor;
    public Color lineColor;

    private Vector3 _gizmosPosition;

    public Vector3 GetPoint(float t)
    {
        return transform.TransformPoint(Bezier.GetPoint(points[0].position, points[1].position, points[2].position, t));
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos)
        {
            return;
        }

        for (float i = 0; i <= 1; i += 0.05f)
        {
            _gizmosPosition = Mathf.Pow(1 - i, 3) * points[0].position +
                3 * Mathf.Pow(1 - i, 2) * i * points[1].position +
                3 * (1 - i) * Mathf.Pow(i, 2) * points[2].position +
                Mathf.Pow(i, 3) * points[3].position;
                
            Gizmos.color = sphereColor;
            Gizmos.DrawSphere(_gizmosPosition, 0.25f);
        }

        Gizmos.color = lineColor;

        Gizmos.DrawLine(new Vector3(points[0].position.x, points[0].position.y, points[0].position.z),
            new Vector3(points[1].position.x, points[1].position.y, points[1].position.z));

        Gizmos.DrawLine(new Vector3(points[2].position.x, points[2].position.y, points[2].position.z),
            new Vector3(points[3].position.x, points[3].position.y, points[3].position.z));
    }
}
