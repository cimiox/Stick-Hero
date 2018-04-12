using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.HeroStates
{
    public class WalkHeroState : IHeroState
    {
        #region Fields
        private const float TIME_TO_END_POSITION = 1.5f;
        private const string SOUND_FALL_PATH = "Sounds/down";
        #endregion


        #region IHeroState
        public IEnumerator StateAction(Hero hero)
        {
            yield return new WaitForSeconds(hero.Level.Stick.parameters.FallTime);

            Vector2 startPosition = hero.transform.position;
            float startTime = Time.realtimeSinceStartup;
            float fraction = 0f;
            Vector2 endPosition = hero.Level.IsWin ?
                        new Vector2(hero.Level.AimPlatform.EndPosition.x - hero.transform.localScale.x, hero.Level.Ground.EndPosition.y) :
                        new Vector2(hero.Level.Ground.EndPosition.x + (hero.transform.localScale.x / 2), hero.Level.Ground.EndPosition.y);

            while (fraction < 1f)
            {
                fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / TIME_TO_END_POSITION);
                hero.Rigidbody.MovePosition(Vector2.Lerp(startPosition, endPosition, fraction));
                yield return null;
            }

            Handle(hero);
        }


        public void Handle(Hero stateObj)
        {
            if (stateObj.Level.IsWin)
            {
                stateObj.Level = GameHandler.Instance.Stage.CurrentLevel;

                stateObj.State = new IdleHeroState();
            }
            else
            {
                stateObj.State = new MainScreenIdleHeroState();

                SoundsHandler.Instance.Play(Resources.Load<AudioClip>(SOUND_FALL_PATH));
            }
        } 
        #endregion
    }
}
