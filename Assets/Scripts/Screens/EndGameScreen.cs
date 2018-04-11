using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : Screen
{
    [SerializeField]
    private Text stageScore;
    [SerializeField]
    private Text bestScore;

    protected override void OnEnable()
    {
        stageScore.text = GameHandler.Instance.Stage.Scores.ToString();
        bestScore.text = GameHandler.Instance.Score.ToString();

        OnWindowEnable(true);
    }


    protected override void OnDisable()
    {
        OnWindowEnable(false);
    }
}
