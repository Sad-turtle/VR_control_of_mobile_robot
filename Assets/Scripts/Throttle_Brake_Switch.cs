using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throttle_Brake_Switch : MonoBehaviour
{
    public float switchRotation;
    private string prevState = "none";
    private connection_to_car connectToCar;
    private void Start()
    {
        connectToCar = FindObjectOfType<connection_to_car>();
    }

    void Update()
    {
        switchRotation = transform.rotation.x;
        if(switchRotation >= -0.3 && switchRotation <= 0.3 && (prevState == "throttle" || prevState == "none" || prevState == "reverse"))
        {
            connectToCar.SendBrakeSignal();
            prevState = "stop";
        }
        if(switchRotation > -1 && switchRotation < -0.3 && (prevState == "stop" || prevState == "none"))
        {
            connectToCar.SendThrottleSignal();
            prevState = "throttle";
        }
        if(switchRotation < 1 && switchRotation > 0.3 && (prevState == "stop" || prevState == "none"))
        {
            connectToCar.SendReverseSignal();
            prevState = "reverse";
        }
    }
}
