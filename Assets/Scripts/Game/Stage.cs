using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// Stage is player game from start to end
/// </summary>
public class Stage : INotifyPropertyChanged
{
    public event Action OnStageStart;
    public event Action OnStageEnd;
    public event PropertyChangedEventHandler PropertyChanged;

    private const float MINIMUM_SPACE = 1;
    private const float MAXIMUM_SPACE = 6;

    private int scores;
    public int Scores
    {
        get { return scores; }
        set
        {
            scores = value;
            OnPropertyChanged("Scores");
        }
    }

    public GameObject GameObject { get; set; }
    public PlatformsFactory PlatformsFactory { get; set; }
    public Level CurrentLevel { get; set; }


    public Stage()
    {
        GameObject = new GameObject("Stage");

        PlatformsFactory = new PlatformsFactory(GameObject.transform);

        var currentPlatform = PlatformsFactory.CreatePlatform(null);

        var space = UnityEngine.Random.Range(MINIMUM_SPACE, MAXIMUM_SPACE);

        CurrentLevel = new Level(currentPlatform,
            PlatformsFactory.CreatePlatform(currentPlatform, space));
        CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;
        CurrentLevel.SpaceBetweenPlatforms = space;

        OnStageStart?.Invoke();
    }


    private void CurrentLevel_OnLevelEnd(Level level, bool isWin)
    {
        if (isWin)
        {
            Scores += level.Score;

            var space = UnityEngine.Random.Range(MINIMUM_SPACE, MAXIMUM_SPACE);

            CurrentLevel = new Level(level.AimPlatform,
                PlatformsFactory.CreatePlatform(level.AimPlatform, space));
            CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;
            CurrentLevel.SpaceBetweenPlatforms = space;
        }
        else
        {
            OnStageEnd?.Invoke();
        }
    }


    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
