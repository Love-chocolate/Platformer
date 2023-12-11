using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    private Rigidbody2D wheelRigidbody;
    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private float minLimit;
    private float maxLimit;

    private void Start()
    {
        wheelRigidbody = GetComponent<Rigidbody2D>();
        wheelJoint = GetComponent<WheelJoint2D>();
    }

    private void Update()
    {
        if (wheelRigidbody.velocity.x > 1f)
        {
            wheelJoint.useMotor = true;
        }
    }
}
