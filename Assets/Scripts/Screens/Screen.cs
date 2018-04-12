using System;
using UnityEngine;

namespace Screens
{
    public abstract class Screen : MonoBehaviour
    {
        #region Fields
        public static event Action<bool, Screen> OnWindowEnableEvent;
        #endregion

        #region Unity lifecycle
        protected abstract void OnEnable();
        protected abstract void OnDisable();
        #endregion

        #region Private methods
        protected void OnWindowEnable(bool flag)
        {
            OnWindowEnableEvent?.Invoke(flag, this);
        } 
        #endregion
    }
}
