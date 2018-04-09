using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.StickState
{
    public interface IStickState : IState<Stick>
    {
        IEnumerator DoStateAction(Stick stick);
    }
}
