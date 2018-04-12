using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level is when i create a stick between two platforms
/// </summary>
public class Level
{

    #region Fields
    /// <summary>
    /// First parameter get what is level end
    /// Second parameter get if is win
    /// </summary>
    public event Action<Level, bool> OnLevelEnd;

    private const string PATH_TO_STICK = "Stick";
    private const string PATH_TO_GROUND = "Ground";
    #endregion


    #region Properties
    public Platform CurrentPlatform { get; set; }
    public Platform AimPlatform { get; set; }
    public Stick Stick { get; set; }
    public Ground Ground { get; set; }
    public int Score { get; set; }
    public bool IsWin { get; set; }
    public float SpaceBetweenPlatforms { get; set; } 
    #endregion


    public Level(Platform currentPlatform, Platform aimPlatform)
    {
        CurrentPlatform = currentPlatform;
        AimPlatform = aimPlatform;

        Stick = UnityEngine.Object.Instantiate(Resources.Load<Stick>(PATH_TO_STICK), CurrentPlatform.EndPosition, Quaternion.identity);
        Stick.transform.SetParent(aimPlatform.transform.parent);

        Ground = UnityEngine.Object.Instantiate(Resources.Load<Ground>(PATH_TO_GROUND), CurrentPlatform.EndPosition, Quaternion.identity);
        Ground.Stick = Stick;
        Ground.transform.SetParent(aimPlatform.transform.parent);

        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }


    ~Level()
    {
        OnLevelEnd = null;
    }


    #region Private methods
    private void TouchHandler_OnTouchUp()
    {
        IsWin = Ground.EndPosition.x > AimPlatform.transform.position.x && Ground.EndPosition.x < AimPlatform.EndPosition.x;

        Score += Convert.ToInt32(IsWin);
        Score += Convert.ToInt32(IsGroundInCenter(Ground.EndPosition));

        if (!IsWin)
        {
            AimPlatform.DisableCollider();
        }

        OnLevelEnd?.Invoke(this, IsWin);

        TouchHandler.OnTouchUp -= TouchHandler_OnTouchUp;
    }


    private bool IsGroundInCenter(Vector2 groundPos)
    {
        return groundPos.x > AimPlatform.Center - Platform.CENTER_SIZE && groundPos.x < AimPlatform.Center + Platform.CENTER_SIZE;
    } 
    #endregion
}
