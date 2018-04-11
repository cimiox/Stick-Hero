using System;
using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    public static event Action<bool, Screen> OnWindowEnableEvent;

    protected abstract void OnEnable();
    protected abstract void OnDisable();

    protected void OnWindowEnable(bool flag)
    {
        OnWindowEnableEvent?.Invoke(flag, this);
    }
}
