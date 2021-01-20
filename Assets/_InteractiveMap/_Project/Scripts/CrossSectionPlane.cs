using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CrossSectionPlane : MonoBehaviour
{
    public Material mat1;

    void Update()
    {         
        mat1.SetVector("_planePosition", transform.position);
        mat1.SetVector("_planeNormal", transform.up);
    }
}