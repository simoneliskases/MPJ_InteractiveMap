using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Camera minimapCamera;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;


    private void Start()
    {
        transform.SetParent(GameManager.currentCar.transform);
        transform.localPosition = positionOffset;
        transform.localEulerAngles = rotationOffset;
    }

    private void LateUpdate()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = 0;
        transform.eulerAngles = rotation;
    }
}
