using State.HeroStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.HeroStates
{
    public class MainScreenIdleHeroState : IHeroState
    {
        #region IHeroState
        public IEnumerator StateAction(Hero hero)
        {
            yield return null;
        }

        public void Handle(Hero stateObj)
        {
            stateObj.State = new IdleHeroState();
        }
        #endregion
    }
}
