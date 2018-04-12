using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    #region Properties
    private static GameHandler instance;
    public static GameHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameHandler>();

                if (instance == null)
                {
                    instance = new GameObject("GameHandler").AddComponent<GameHandler>();
                }
            }

            return instance;
        }
    }
    public float Score
    {
        get { return PlayerPrefs.GetFloat("Score", 0); }
        set
        {
            if (PlayerPrefs.GetFloat("Score", 0) < value)
            {
                PlayerPrefs.SetFloat("Score", value);
            }
        }
    }
    public Hero Hero { get; set; }
    public Stage Stage { get; set; }
    #endregion Properties


    #region Fields   
    [SerializeField]
    private GameObject GameScreen;
    [SerializeField]
    private Platform StartPlatform;
    [SerializeField]
    private GameObject MainScreen;
    [SerializeField]
    private GameObject EndGameScreen;
    private Vector2 heroStartPosition = new Vector2(1, 2);


    public event Action OnGameStart;


    private const string PATH_TO_HERO = "Hero";
    #endregion Fields


    #region Unity lifecycle
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        CreateHero();
    }
    #endregion Unity lifecycle


    #region Public methods
    public void PlayGame()
    {
        Stage = new Stage(StartPlatform);

        Stage.OnStageEnd += Stage_OnStageEnd;

        Hero.transform.position = heroStartPosition;
        Hero.transform.rotation = Quaternion.identity;

        OnGameStart?.Invoke();

        GameScreen.SetActive(true);
    }
    

    public void ReturnHome()
    {
        ClearScene();

        CreateHero();
    }


    public void RestartGame()
    {
        ClearScene();

        CreateHero();

        PlayGame();
    }
    #endregion Public methods


    #region Event handlers
    private void Stage_OnStageEnd()
    {
        Score = Stage.Scores;

        EndGameScreen.SetActive(true);
    }
    #endregion Event handlers


    #region Private methods
    private void CreateHero()
    {
        Hero = UnityEngine.Object.Instantiate(Resources.Load<Hero>(PATH_TO_HERO), heroStartPosition, Quaternion.identity);
    }


    private void ClearScene()
    {
        try
        {
            Destroy(Stage.GameObject);
        }
        catch (Exception ex)
        {
            print(ex.Message);
        }

        try
        {
            Destroy(FindObjectOfType<Hero>().gameObject);
        }
        catch (Exception ex)
        {
            print(ex.Message);
        }
    }
    #endregion Private methods
}
