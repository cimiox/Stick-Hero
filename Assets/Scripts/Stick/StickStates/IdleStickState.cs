﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.StickState
{
    public class IdleStickState : IStickState
    {
        #region IStickState
        public IEnumerator DoStateAction(Stick stick)
        {
            yield return null;
        }

        public void Handle(Stick stick)
        {
            stick.State = new RaiseStickState();
        } 
        #endregion
    }
}
