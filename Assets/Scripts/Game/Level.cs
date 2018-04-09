using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level is when i create a stick between two platforms
/// </summary>
public class Level
{
    /// <summary>
    /// First parameter get what is level end
    /// Second parameter get if is win
    /// </summary>
    public event Action<Level, bool> OnLevelEnd;

    public Platform CurrentPlatform { get; set; }
    public Platform AimPlatform { get; set; }
    public Stick Stick { get; set; }
    public int Score { get; set; }


    public Level(Platform currentPlatform, Platform aimPlatform)
    {
        CurrentPlatform = currentPlatform;
        AimPlatform = aimPlatform;

        TouchHandler.OnTouchDown += TouchHandler_OnTouchDown;
        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }


    private void TouchHandler_OnTouchDown()
    {
        //TODO: Create stick
    }


    private void TouchHandler_OnTouchUp()
    {
        //TODO: Get distance

        OnLevelEnd?.Invoke(this, false);
    }
}
