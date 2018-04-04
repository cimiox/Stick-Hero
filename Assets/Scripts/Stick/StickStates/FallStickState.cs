using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStickState : IStickState
{
    public IEnumerator DoStateAction(Stick stick)
    {
        //TODO: Fall logic
        throw new System.NotImplementedException();
    }

    public void Handle(Stick stick)
    {
        stick.State = new IdleStickState();
    }
}
