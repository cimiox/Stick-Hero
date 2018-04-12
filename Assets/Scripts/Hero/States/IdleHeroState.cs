using State.HeroStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.HeroStates
{
    public class IdleHeroState : IHeroState
    {
        #region Fields
        private const float TIME_TO_END_POSITION = 0.3f;
        #endregion


        #region IHeroState
        public IEnumerator StateAction(Hero hero)
        {
            yield return new WaitUntil(() => hero.Level != null);
            yield return new WaitUntil(() => hero.Level.CurrentPlatform != null);

            Vector2 startPosition = hero.transform.position;
            float startTime = Time.realtimeSinceStartup;
            float fraction = 0f;

            while (fraction < 1f)
            {
                fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / TIME_TO_END_POSITION);
                hero.transform.position = Vector2.Lerp(startPosition, hero.Level.CurrentPlatform.EndPosition, fraction);
                yield return null;
            }
        }


        public void Handle(Hero stateObj)
        {
            stateObj.State = new WalkHeroState();
        }
        #endregion
    }
}
