using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsFactory
{
    private const string RESOURCES_PLATFORM_PATH = "Platform";
    private const string RESOURCES_PLATFORM_CENTER_PATH = "PlatformCenter";
    private const float START_PLATFORM_SIZE = 3;
    private const float MINIMUM_SCALE = 1;
    private const float MAXIMUM_SCALE = 5;

    public Transform Parent { get; set; }

    public PlatformsFactory(Transform parent)
    {
        Parent = parent;
    }

    public Platform CreatePlatform(Platform previosPlatform, float space = 0)
    {
        float spaceBetweenPlatforms = space;

        var platform = UnityEngine.Object.Instantiate(
            Resources.Load<Platform>(RESOURCES_PLATFORM_PATH),
            new Vector3(previosPlatform == null ? 0 : previosPlatform.EndPosition.x + spaceBetweenPlatforms, 2, 0),
            Quaternion.identity);

        platform.transform.SetParent(Parent);

        platform.transform.localScale = new Vector2(
            UnityEngine.Random.Range(MINIMUM_SCALE, MAXIMUM_SCALE),
            platform.transform.localScale.y);

        if (previosPlatform == null)
        {
            platform.transform.localScale = new Vector2(
                START_PLATFORM_SIZE,
                platform.transform.localScale.y);
        }

        platform.SpaceBetweenPlatforms = previosPlatform == null ? 0 : spaceBetweenPlatforms;

        Object.Instantiate(Resources.Load<GameObject>(RESOURCES_PLATFORM_CENTER_PATH),
            new Vector3(platform.Center, platform.transform.position.y, -1),
            Quaternion.identity).transform.SetParent(Parent);

        return platform;
    }
}
