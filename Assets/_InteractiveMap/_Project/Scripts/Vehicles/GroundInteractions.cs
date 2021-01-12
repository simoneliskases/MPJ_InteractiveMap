using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteractions : MonoBehaviour
{
    public CarController carController;
    public Rigidbody carRigidbody;

    public float groundDrag = 0;
    public float waterDrag = 2;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            carRigidbody.drag = 2;
        }
        else if(other.gameObject.tag == "Ground")
        {
            carRigidbody.drag = 0;
        }
    }
}
