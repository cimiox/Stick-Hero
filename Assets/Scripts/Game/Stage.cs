using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// Stage is player game from start to death
/// </summary>
public class Stage : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged; 
    #endregion


    #region Fields
    public event Action OnStageStart;
    public event Action OnStageEnd;
    

    private const float MINIMUM_SPACE = 1;
    private const float MAXIMUM_SPACE = 6;
    #endregion


    #region Properties
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
    #endregion


    public Stage(Platform startPlatform)
    {
        GameObject = new GameObject("Stage");

        PlatformsFactory = new PlatformsFactory(GameObject.transform);

        var space = UnityEngine.Random.Range(MINIMUM_SPACE, MAXIMUM_SPACE);

        CurrentLevel = new Level(startPlatform,
            PlatformsFactory.CreatePlatform(startPlatform, space));

        CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;
        CurrentLevel.SpaceBetweenPlatforms = space;

        OnStageStart?.Invoke();
    }


    #region Event handlers
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
    #endregion
}
