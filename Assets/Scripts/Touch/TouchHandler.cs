using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    public static event Action OnTouchDown;
    public static event Action OnTouchUp;
    #endregion


    #region IPointerDownHandler
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnTouchDown?.Invoke();
    }
    #endregion


    #region IPointerUpHandler
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        OnTouchUp?.Invoke();
    }
    #endregion
}
