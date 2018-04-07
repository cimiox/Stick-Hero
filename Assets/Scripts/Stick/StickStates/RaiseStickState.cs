using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseStickState : IStickState
{
    public IEnumerator DoStateAction(Stick stick)
    {
        while (true)
        {
            stick.transform.localScale = new Vector2(stick.transform.localScale.x,
                stick.transform.localScale.y + stick.parameters.RaiseSpeed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }
    }

    public void Handle(Stick stick)
    {
        //TODO: Write Raise logic
        stick.State = new FallStickState();
    }
}
