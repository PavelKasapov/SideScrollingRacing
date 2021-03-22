using UnityEngine;
using Zenject;

public class Vehicle : MonoBehaviour
{
    public VehicleStats stats;
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;

    private bool _isAccelerating = false;
    private bool _isBraking = false;
    private JointMotor2D _frontMotor;
    private JointMotor2D _backMotor;
    private JointMotor2D _frontBreakMotor;
    private JointMotor2D _backBreakMotor;
    private GameObject _startPoint;

    [Inject]
    public void Construct ([Inject(Id = "startPoint")] GameObject startPoint)
    {
        _startPoint = startPoint;
    }
    private void Awake()
    {
        transform.position = _startPoint.transform.position;
        _frontMotor = CreateMotor(stats.maxSpeedFront, stats.maxTorqueFront);
        _backMotor = CreateMotor(stats.maxSpeedBack, stats.maxTorqueBack);
        _frontBreakMotor = CreateMotor(0f, stats.maxTorqueBreakFront);
        _backBreakMotor = CreateMotor(0f, stats.maxTorqueBreakBack);
    }
    public void Accelerate(bool accelerateInput)
    {
        _isAccelerating = accelerateInput;
        if ((_isAccelerating) && (!_isBraking))
        {
            frontWheel.motor = _frontMotor;
            backWheel.motor = _backMotor;
            frontWheel.useMotor = true;
            backWheel.useMotor = true;
        }
        else if (!_isAccelerating)
        {
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
            if (_isBraking)
            {
                Brake(true);
            }
        }
    }

    public void Brake(bool brakeInput)
    {
        _isBraking = brakeInput;
        if ((_isBraking) && (!_isAccelerating))
        {
            frontWheel.motor = _frontBreakMotor;
            backWheel.motor = _backBreakMotor;
            frontWheel.useMotor = true;
            backWheel.useMotor = true;
        }
        else if (!_isBraking)
        {
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
            if (_isAccelerating)
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

    public class Factory : PlaceholderFactory<string, Vehicle>
    {
    }
}


