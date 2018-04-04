using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStickState : IStickState
{
    public IEnumerator DoStateAction(Stick stick)
    {
        yield return null;
    }

    public void Handle(Stick stick)
    {
        stick.State = new RaiseStickState();
    }
}
