﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingElo : Thing
{

    protected override void TTTAwake()
    {
        //camera
        settings.cameraOffset = 15; //distance from camera to object center on 3rd personn camera following mode

        //Movement
        settings.acceleration = 3f; //use Random.range to get a random number within a range
        settings.drag = 1.8f; // the bigger, the slower
        settings.mass = 0.2f; // the bigger, the heavier, the more acceleration it needs to get this moving, also can push away lighter THINGS
        settings.getNewDestinationInterval = 5; //how often to get a new target to run to, in (seconds)
        settings.newDestinationRange = 40; // how far the new destination could be 

        settings.myCubeColor = Color.red; //cube's color produced by you
    }

    protected override void TTTStart()
    {
        //examples:
        Speak("I am born!");
        //we recommend keep this one, or you can write your own rule of moving
        InvokeRepeating("RandomSetDestination", 0, settings.getNewDestinationInterval); //call "RandomSetDestination" method every "getNewDestinationInterval" seconds
    }

    protected override void TTTUpdate()
    {

    }


    protected override void OnMeetingSomeone(GameObject other)
    {
        //Example
        Speak("I met " + other.name, 2f);
    }

    protected override void OnLeavingSomeone(GameObject other)
    {
        //Example:
        Spark(Color.red, 15);
    }

    protected override void OnNeighborSpeaking()
    {
        CreateCube();
    }

    protected override void OnTouchWater()
    {
        ChangeColor(Color.blue);
    }

    protected override void OnLeaveWater()
    {
        ResetColor();
    }

    protected override void OnNeigborSparkingParticles()
    {
        CreateCube();
    }

    protected override void OnSunset()
    {
        for (int i = 0; i < 4; i++)
        {
            CreateCube();
        }

    }

    protected override void OnSunrise()
    {
        //Example:
        PlaySound("cartoon-pinch");
    }





}
