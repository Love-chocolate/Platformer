using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;
    private bool isPlayerOnPlatform;

    [SerializeField] private bool isVertical;

    [Header("For horizontal platform")]
    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    private void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
        //sliderJoint.motor = motor;
    }

    private void Update()
    {
        if (isVertical)
        {
            if (sliderJoint.limitState == JointLimitState2D.UpperLimit && sliderJoint.useMotor == true)
            {
                motor.motorSpeed = -motor.motorSpeed;
                sliderJoint.motor = motor;
            }
            else if (sliderJoint.limitState == JointLimitState2D.LowerLimit && isPlayerOnPlatform == false)
            {
                sliderJoint.useMotor = false;
            }
        }
        else
        {
            if(sliderJoint.transform.position.x <= minLimit || sliderJoint.transform.position.x >= maxLimit)
            {
                motor.motorSpeed = -motor.motorSpeed;
                sliderJoint.motor = motor;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            sliderJoint.useMotor = true;
        }
    }
}
