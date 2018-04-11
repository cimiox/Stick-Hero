using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    public static GameHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameHandler>();

                print(FindObjectOfType<GameHandler>());

                if (instance == null)
                {
                    instance = new GameObject("GameHandler").AddComponent<GameHandler>();
                }
            }

            return instance;
        }
    }

    public event Action OnGameStart;

    private const string PATH_TO_HERO = "Hero";

    private Vector2 heroStartPosition = new Vector2(1, 3);


    public float Score
    {
        get { return PlayerPrefs.GetFloat("Score", 0); }
        set
        {
            if (PlayerPrefs.GetFloat("Score", 0) < value)
            {
                PlayerPrefs.GetFloat("Score", value);
            }
        }
    }


    public Hero Hero { get; set; }
    public Stage Stage { get; set; }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Hero = UnityEngine.Object.Instantiate(Resources.Load<Hero>(PATH_TO_HERO), heroStartPosition, Quaternion.identity);

        PlayGame();
    }


    public void PlayGame()
    {
        Stage = new Stage();

        Stage.OnStageEnd += Stage_OnStageEnd;

        Hero.transform.position = heroStartPosition;
        Hero.transform.rotation = Quaternion.identity;

        OnGameStart?.Invoke();
    }


    private void Stage_OnStageEnd()
    {
        Score = Stage.Scores;
    }


    public void RestartGame()
    {
        Destroy(Stage.GameObject);
        Destroy(FindObjectOfType<Hero>().gameObject);

        Hero = UnityEngine.Object.Instantiate(Resources.Load<Hero>(PATH_TO_HERO), heroStartPosition, Quaternion.identity);

        PlayGame();
    }
}
