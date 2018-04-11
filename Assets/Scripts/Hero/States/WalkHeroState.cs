using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkHeroState : IHeroState
{
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
            //TODO: Write in scriptable object parameters
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / 1.5f);
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
        }
    }
}
