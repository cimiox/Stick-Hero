using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.HeroStates
{
    public interface IHeroState : IState<Hero>
    {
        IEnumerator StateAction(Hero hero);
    } 
}
