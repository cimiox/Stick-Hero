using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //TODO: Rewrite to simple parameters
    [SerializeField]
    private Stick stick;

    private void OnEnable()
    {
        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }


    private void TouchHandler_OnTouchUp()
    {
        if (stick != null)
        {
            transform.localScale = new Vector2(
                    stick.transform.localScale.y,
                    transform.localScale.y);
        }
    }
}
