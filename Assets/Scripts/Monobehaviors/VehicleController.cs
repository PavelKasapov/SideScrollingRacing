using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class VehicleController : MonoBehaviour
{
    public VehicleStats stats;
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;
    private bool isAccelerating = false;
    private bool isBraking = false;

    JointMotor2D frontMotor;
    JointMotor2D backMotor;
    JointMotor2D frontBreakMotor;
    JointMotor2D backBreakMotor;

    [Inject]
    public void Construct ([Inject(Id = "startPoint")] GameObject startPoint)
    {
        transform.position = startPoint.transform.position;
    }
    private void Awake()
    {
        frontMotor = CreateMotor(stats.maxSpeedFront, stats.maxTorqueFront);
        backMotor = CreateMotor(stats.maxSpeedBack, stats.maxTorqueBack);
        frontBreakMotor = CreateMotor(0f, stats.maxTorqueBreakFront);
        backBreakMotor = CreateMotor(0f, stats.maxTorqueBreakBack);
    }
    public void Accelerate(bool accelerateInput)
    {
        isAccelerating = accelerateInput;
        if ((isAccelerating) && (!isBraking))
        {
            frontWheel.motor = frontMotor;
            backWheel.motor = backMotor;
            frontWheel.useMotor = true;
            backWheel.useMotor = true;
        }
        else if (!isAccelerating)
        {
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
            if (isBraking)
            {
                Brake(true);
            }
        }
    }

    public void Brake(bool brakeInput)
    {
        isBraking = brakeInput;
        if ((isBraking) && (!isAccelerating))
        {
            frontWheel.motor = frontBreakMotor;
            backWheel.motor = backBreakMotor;
            frontWheel.useMotor = true;
            backWheel.useMotor = true;
        }
        else if (!isBraking)
        {
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
            if (isAccelerating)
            {
                Accelerate(true);
            }
        }
    }

    private JointMotor2D CreateMotor(float speed, float torque)
    {
        JointMotor2D motor = new JointMotor2D()
        {
            motorSpeed = -speed,
            maxMotorTorque = torque
        };
        return motor;
    }
}


