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
            if(_mat.GetVector("_planePosition") == null || _mat.GetVector("_planeNormal") == null)
            {
                Debug.LogWarning("Material " + _mat + "off CrossSectionPlane doesn't have the Vectors _planePosition or _planeNormal");
                return;
            }

            _mat.SetVector("_planePosition", transform.position);
            _mat.SetVector("_planeNormal", transform.up);
        }
    }
}