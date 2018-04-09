using State.StickState;
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
        State = new RaiseStickState();

        TouchHandler.OnTouchUp += TouchHandler_OnTouchUp;
    }

    private void TouchHandler_OnTouchUp()
    {
        Request();
    }


    private void OnDisable()
    {
        TouchHandler.OnTouchUp -= TouchHandler_OnTouchUp;
    }


    public void Request()
    {
        State.Handle(this);
    }
}
