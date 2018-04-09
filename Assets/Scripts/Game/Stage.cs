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
    public event Action OnStageEnd;
    public event PropertyChangedEventHandler PropertyChanged;

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


    public PlatformsFactory PlatformsFactory { get; set; }
    public Level CurrentLevel { get; set; }


    public Stage()
    {
        PlatformsFactory = new PlatformsFactory();

        var currentPlatform = PlatformsFactory.CreatePlatform(null);

        CurrentLevel = new Level(currentPlatform,
            PlatformsFactory.CreatePlatform(currentPlatform));
        CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;
    }


    private void CurrentLevel_OnLevelEnd(Level level, bool isWin)
    {
        if (isWin)
        {
            Scores += level.Score;

            CurrentLevel = new Level(level.AimPlatform,
                PlatformsFactory.CreatePlatform(level.AimPlatform));
            CurrentLevel.OnLevelEnd += CurrentLevel_OnLevelEnd;
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
