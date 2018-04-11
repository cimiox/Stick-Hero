using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenIdleHeroState : IHeroState
{
    public IEnumerator StateAction(Hero hero)
    {
        yield return null;
    }

    public void Handle(Hero stateObj)
    {
        stateObj.State = new IdleHeroState();
    }
}
