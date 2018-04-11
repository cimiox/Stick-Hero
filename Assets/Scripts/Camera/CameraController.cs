using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Vector3 mainScreenPosition = new Vector3(0.7f, 6f, -10);
    private Vector3 gameScreenPosition = new Vector3(5.7f, 5f, -10);

    private const float Z_POSITION = -10;
    private const float TIME_TO_END_POSITION = 1f;

    private void OnEnable()
    {
        GameHandler.Instance.OnGameStart += Instance_OnGameStart;

        Screen.OnWindowEnableEvent += Screen_OnWindowEnableEvent;
    }


    private void Screen_OnWindowEnableEvent(bool flag, Screen screen)
    {
        if (flag && screen is MainScreen)
        {
            StartCoroutine(SetPosition(mainScreenPosition));
        }
    }


    private void Instance_OnGameStart()
    {
        GameHandler.Instance.Stage.OnStageEnd += Stage_OnStageEnd;
        GameHandler.Instance.Stage.CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;
        StartCoroutine(SetPosition(gameScreenPosition));
    }


    private void CurrentLevel_OnLevelEnd(Level level, bool isWin)
    {
        level.OnLevelEnd -= CurrentLevel_OnLevelEnd;

        GameHandler.Instance.Stage.CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;

        StartCoroutine(SetPosition(new Vector3(
            transform.position.x + level.SpaceBetweenPlatforms,
            transform.position.y,
            transform.position.z)));
    }


    private void Stage_OnStageEnd()
    {
        GameHandler.Instance.Stage.OnStageEnd -= Stage_OnStageEnd;
        StartCoroutine(SetPosition(mainScreenPosition));
    }


    private void OnDisable()
    {
        GameHandler.Instance.OnGameStart -= Instance_OnGameStart;
        Screen.OnWindowEnableEvent -= Screen_OnWindowEnableEvent;
    }


    private IEnumerator SetPosition(Vector3 endPosition)
    {
        Vector3 startPosition = transform.position;
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0f;

        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / TIME_TO_END_POSITION);
            transform.position = Vector3.Lerp(startPosition, endPosition, fraction);
            yield return null;
        }
    }
}
