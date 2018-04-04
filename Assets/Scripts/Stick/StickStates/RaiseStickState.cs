using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseStickState : IStickState
{
    public IEnumerator DoStateAction(Stick stick)
    {
        //TODO: Raise logic
        throw new System.NotImplementedException();
    }

    public void Handle(Stick stick)
    {
        //TODO: Write Raise logic
        stick.State = new FallStickState();
    }
}
