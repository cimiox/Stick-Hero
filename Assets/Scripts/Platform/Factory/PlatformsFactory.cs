using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsFactory
{
    private const string RESOURCES_PLATFORM_PATH = "Platforms/Platform";


    public Platform CreatePlatform(Platform previosPlatform)
    {
        //TODO: Create scriptable object with parameters for factory
        float spaceBetweenPlatforms = Random.Range(1, 6);

        var platform = UnityEngine.Object.Instantiate(
            Resources.Load<Platform>(RESOURCES_PLATFORM_PATH),
            new Vector3(previosPlatform == null ? 0 : previosPlatform.transform.position.x + previosPlatform.Size + spaceBetweenPlatforms, 0, 0),
            Quaternion.identity);

        platform.SpaceBetweenPlatforms = previosPlatform == null ? 0 : spaceBetweenPlatforms;

        //TODO: Add center

        return platform;
    }
}
