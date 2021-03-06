﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    #region Properties
    public Stick Stick { get; set; } 
    
    public float Size
    {
        get { return transform.lossyScale.x / 2; }
    }

    public Vector2 EndPosition
    {
        get { return new Vector2(
          transform.position.x + Size,
          transform.position.y);
        }
    }
    #endregion


    #region Unity lifecycle
    private void OnEnable()
    {
        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }


    private void OnDisable()
    {
        TouchHandler.OnTouchUp -= TouchHandler_OnTouchUp;
    }
    #endregion


    #region Event handlers
    private void TouchHandler_OnTouchUp()
    {
        if (Stick != null)
        {
            transform.localScale = new Vector2(
                    Stick.transform.localScale.y,
                    transform.localScale.y);
        }
    } 
    #endregion
}
