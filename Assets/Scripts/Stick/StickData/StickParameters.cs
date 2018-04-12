using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickParameters : ScriptableObject
{
    #region Properties
    [SerializeField]
    private float raiseSpeed;
    public float RaiseSpeed
    {
        get { return raiseSpeed; }
        set { raiseSpeed = value; }
    }

    [SerializeField]
    private float fallTime;
    public float FallTime
    {
        get { return fallTime; }
        set { fallTime = value; }
    } 
    #endregion
}
