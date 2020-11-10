using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Score score;
    public Timer timer;

    [Header("Car Movement")]
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBoosted;
    
    public WheelCollider frontDriverWheel;
    public WheelCollider frontPassengerWheel;
    public WheelCollider rearDriverWheel;
    public WheelCollider rearPassengerWheel;

    public Transform frontDriverTransform;
    public Transform frontPassengerTransform;
    public Transform rearDriverTransform;
    public Transform rearPassengerTransform;

    public float maxSteerAngle = 30f;
    public float motorForce = 120f;
    public float boostValue;
    public float boostTime;


    //Car Movement

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    
    private void Steer()
    {
        steerAngle = maxSteerAngle * horizontalInput;
        frontDriverWheel.steerAngle = steerAngle;
        frontPassengerWheel.steerAngle = steerAngle;
    }

    private void Accelerate()
    {
        frontDriverWheel.motorTorque = verticalInput * motorForce;
        frontPassengerWheel.motorTorque = verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPos(frontDriverWheel, frontDriverTransform);
        UpdateWheelPos(frontPassengerWheel, frontPassengerTransform);
        UpdateWheelPos(rearDriverWheel, rearDriverTransform);
        UpdateWheelPos(rearPassengerWheel, rearPassengerTransform);
    }

    private void UpdateWheelPos(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }


    //Pickups

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            score.coinCount++; 
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "TimeBoost")
        {
            timer.TimeBoost();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "SpeedBoost")
        {
            if (!isBoosted)
            {
                Destroy(other.gameObject);

                motorForce += boostValue;
                isBoosted = true;
                float _currentTime = Time.deltaTime;

                if(_currentTime > boostTime)
                {
                    motorForce -= boostValue;
                    isBoosted = false;
                }
            }
        }
    }
}
