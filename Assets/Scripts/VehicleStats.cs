using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vehicle Stats", menuName = "Vehicle stats")]
public class VehicleStats : ScriptableObject
{
    public string vehicleName;
    public float maxSpeedFront;
    public float maxTorqueFront;
    public float maxTorqueBreakFront;
    public float maxSpeedBack;
    public float maxTorqueBack;
    public float maxTorqueBreakBack;
}
