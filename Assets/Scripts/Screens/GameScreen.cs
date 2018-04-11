using UnityEngine.UI;

public class GameScreen : Screen
{
    [UnityEngine.SerializeField]
    private Text scoreText;

    protected override void OnEnable()
    {
        GameHandler.Instance.Stage.PropertyChanged += Stage_PropertyChanged;

        OnWindowEnable(true);
    }

    private void Stage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("Scores"))
        {
            scoreText.text = (sender as Stage).Scores.ToString();
        }
    }

    protected override void OnDisable()
    {
        GameHandler.Instance.Stage.PropertyChanged -= Stage_PropertyChanged;

        OnWindowEnable(false);
    }
}
