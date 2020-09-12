using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dataHolder
{
    //data members for the speed and direction
    private double windSpeed;
    private double windDirection;

    //constructor for the speed and direction values
    public dataHolder(double windSpeed, double windDirection) {
        //the windSpeed in the current object is the windSpeed data member
        this.windSpeed = windSpeed;
        //the windDirection in the current object is the windDirection data member
        this.windDirection = windDirection;
    }

    private double xComponent;
    private double yComponent;

    //find the x and y components
    public void findComponents()
    {

        xComponent = (windSpeed) * (Math.Cos(windDirection));
        yComponent = (windSpeed) * (Math.Sin(windDirection));

    }


}
