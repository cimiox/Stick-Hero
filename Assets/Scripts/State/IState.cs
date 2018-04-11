using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public interface IState<T>
    {
        void Handle(T stateObj);
    }
}
