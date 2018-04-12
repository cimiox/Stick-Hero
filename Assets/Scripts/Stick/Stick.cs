using State.StickState;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    #region Fields
    [SerializeField]
    public StickParameters parameters; 
    #endregion


    #region Properties
    public Coroutine StateAction { get; set; }
    private IStickState state;
    public IStickState State
    {
        get { return state; }
        set
        {
            if (value != state)
            {
                if (StateAction != null)
                {
                    StopCoroutine(StateAction);
                }

                state = value;

                StateAction = StartCoroutine(state.DoStateAction(this));
            }
        }
    }
    #endregion


    #region Unity lifecycle
    private void OnEnable()
    {
        State = new IdleStickState();

        TouchHandler.OnTouchDown += TouchHandler_OnTouchDown;
        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }


    private void OnDisable()
    {
        TouchHandler.OnTouchUp -= TouchHandler_OnTouchUp;
        TouchHandler.OnTouchDown -= TouchHandler_OnTouchDown;
    }
    #endregion


    #region Event handlers
    private void TouchHandler_OnTouchDown()
    {
        TouchHandler.OnTouchDown -= TouchHandler_OnTouchDown;
        Request();
    }


    private void TouchHandler_OnTouchUp()
    {
        TouchHandler.OnTouchUp -= TouchHandler_OnTouchUp;
        Request();
    }
    #endregion


    #region Public methods
    public void Request()
    {
        State.Handle(this);
    } 
    #endregion
}
