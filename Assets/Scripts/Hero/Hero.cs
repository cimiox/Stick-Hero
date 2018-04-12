using State.HeroStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Hero : MonoBehaviour
{
    #region Properties
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
                try
                {
                    if (StateAction != null)
                    {
                        StopCoroutine(StateAction);
                    }

                    state = value;

                    StateAction = StartCoroutine(state.StateAction(this));
                }
                catch (System.Exception)
                {
                }

            }
        }
    }
    public Rigidbody2D Rigidbody { get; set; }
    #endregion


    #region Unity lifecycle
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


    private void OnDisable()
    {
        GameHandler.Instance.Stage.OnStageStart -= Instance_OnGameStart;
        TouchHandler.OnTouchUp -= Request;
    }
    #endregion


    #region Event handlers
    private void Instance_OnGameStart()
    {
        Level = GameHandler.Instance.Stage.CurrentLevel;

        Request();
    }
    #endregion


    #region Private methods
    /// <summary>
    /// Request state Handle state to another state
    /// </summary>
    protected void Request()
    {
        State.Handle(this);
    } 
    #endregion
}
