using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action OnTouchDown;
    public static event Action OnTouchUp;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnTouchDown?.Invoke();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        OnTouchUp?.Invoke();
    }
}
