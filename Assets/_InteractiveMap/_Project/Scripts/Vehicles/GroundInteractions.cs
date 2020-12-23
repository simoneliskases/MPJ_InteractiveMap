using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteractions : MonoBehaviour
{
    public CarController carController;

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision");
        switch (collision.gameObject.tag)
        {
            case ("Ground"):
                carController._tempMotorForce = carController.groundMotorForce;
                break;
            case ("Water"):
                carController._tempMotorForce = carController.waterMotorForce;
                break;
        }
    }
}
