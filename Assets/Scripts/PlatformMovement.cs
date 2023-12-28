using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    private void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
    }

    public void ChangePlatformDirection()
    {
        motor.motorSpeed = -motor.motorSpeed;
        sliderJoint.motor = motor;
    }
}
