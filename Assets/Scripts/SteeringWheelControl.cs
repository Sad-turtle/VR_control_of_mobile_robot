using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SteeringWheelControl : MonoBehaviour
{
    public static float currentSteeringWheelRotation = 0f;
    private string stateOfWheel = "left";
    private connection_to_car connectToCar;

    private void Start()
    {
        connectToCar = FindObjectOfType<connection_to_car>();
    }
    void Update()
    {
        currentSteeringWheelRotation = transform.rotation.x;

        if (currentSteeringWheelRotation >= -0.3 && currentSteeringWheelRotation <= 0.3 && (stateOfWheel == "left" || stateOfWheel == "right"))
        {
            connectToCar.SendStayStraightSignal();
            stateOfWheel = "straight";
        }
        if (currentSteeringWheelRotation > -1 && currentSteeringWheelRotation < -0.3 && stateOfWheel == "straight")
        {
            connectToCar.SendTurnLeftSignal();
            stateOfWheel = "left";
        }
        if (currentSteeringWheelRotation < 1 && currentSteeringWheelRotation > 0.3 && stateOfWheel == "straight")
        {
            connectToCar.SendTurnRightSignal();
            stateOfWheel = "right";
        }
    }


}

