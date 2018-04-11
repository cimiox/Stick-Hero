using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeroState : IState<Hero>
{
    IEnumerator StateAction(Hero hero);
}
