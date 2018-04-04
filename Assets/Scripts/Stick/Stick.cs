using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    //TODO: Create Scriptable object who save some values about raise speed, or fall time and other data

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

                StartCoroutine(state.DoStateAction(this));
            }
        }
    }

    private void OnEnable()
    {
        State = new IdleStickState();
    }

    public void Request()
    {
        State.Handle(this);
    }
}
