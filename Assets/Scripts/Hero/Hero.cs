using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Hero : MonoBehaviour
{
    public Level Level { get; set; }
    public Coroutine StateAction { get; set; }


    private IHeroState state;
    public IHeroState State
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

                StateAction = StartCoroutine(state.StateAction(this));
            }
        }
    }

    public Rigidbody2D Rigidbody { get; set; }


    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        State = new MainScreenIdleHeroState();

        GameHandler.Instance.OnGameStart += Instance_OnGameStart;
        TouchHandler.OnTouchUp += Request;
    }


    private void Instance_OnGameStart()
    {
        Level = GameHandler.Instance.Stage.CurrentLevel;

        Request();
    }


    private void OnDisable()
    {
        GameHandler.Instance.Stage.OnStageStart -= Instance_OnGameStart;
        TouchHandler.OnTouchUp -= Request;
    }


    protected void Request()
    {
        State.Handle(this);
    }
}
