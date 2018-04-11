using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleHeroState : IHeroState
{
    public IEnumerator StateAction(Hero hero)
    {
        yield return new WaitUntil(() => hero.Level != null);
        yield return new WaitUntil(() => hero.Level.CurrentPlatform != null);

        Vector2 startPosition = hero.transform.position;
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0f;

        while (fraction < 1f)
        {
            //TODO: Write in scriptable object parameters
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / 0.3f);
            hero.transform.position = Vector2.Lerp(startPosition, hero.Level.CurrentPlatform.EndPosition, fraction);
            yield return null;
        }
    }

    public void Handle(Hero stateObj)
    {
        stateObj.State = new WalkHeroState();
    }
}
