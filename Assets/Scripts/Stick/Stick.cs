using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField]
    public StickParameters parameters;

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


    private void OnEnable()
    {
        State = new IdleStickState();

        TouchHandler.OnTouchDown += TouchHandler_OnTouch;
        TouchHandler.OnTouchUp += TouchHandler_OnTouch;
    }


    private void TouchHandler_OnTouch()
    {
        Request();
    }


    private void OnDisable()
    {
        TouchHandler.OnTouchDown -= TouchHandler_OnTouch;
        TouchHandler.OnTouchUp -= TouchHandler_OnTouch;
    }


    public void Request()
    {
        State.Handle(this);
    }
}
