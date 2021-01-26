using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CrossSectionPlane : MonoBehaviour
{
    public Material[] materials;

    private void Update()
    {
        foreach(var _mat in materials)
        {
            _mat.SetVector("_planePosition", transform.position);
            _mat.SetVector("_planeNormal", transform.up);
        }
    }
}