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
    private JointMotor2D _frontMotor;
    private JointMotor2D _backMotor;
    private JointMotor2D _frontBreakMotor;
    private JointMotor2D _backBreakMotor;
    private GameObject _startPoint;

    [Inject]
    public void Construct ([Inject(Id = "startPoint")] GameObject startPoint)
    {
        _startPoint = startPoint;
        transform.position = _startPoint.transform.position;
    }
    private void Awake()
    {
        _frontMotor = CreateMotor(stats.maxSpeedFront, stats.maxTorqueFront);
        _backMotor = CreateMotor(stats.maxSpeedBack, stats.maxTorqueBack);
        _frontBreakMotor = CreateMotor(0f, stats.maxTorqueBreakFront);
        _backBreakMotor = CreateMotor(0f, stats.maxTorqueBreakBack);
    }
    public void Accelerate(bool accelerateInput)
    {
        isAccelerating = accelerateInput;
        if ((isAccelerating) && (!isBraking))
        {
            frontWheel.motor = _frontMotor;
            backWheel.motor = _backMotor;
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
            frontWheel.motor = _frontBreakMotor;
            backWheel.motor = _backBreakMotor;
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
        return new JointMotor2D()
        {
            motorSpeed = -speed,
            maxMotorTorque = torque
        };
    }
}


