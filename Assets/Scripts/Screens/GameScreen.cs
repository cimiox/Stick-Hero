using UnityEngine.UI;

namespace Screens
{
    public class GameScreen : Screen
    {
        #region Fields
        [UnityEngine.SerializeField]
        private Text scoreText;
        #endregion


        #region Unity lifecycle
        protected override void OnEnable()
        {
            GameHandler.Instance.Stage.PropertyChanged += Stage_PropertyChanged;

            OnWindowEnable(true);
        }


        protected override void OnDisable()
        {
            GameHandler.Instance.Stage.PropertyChanged -= Stage_PropertyChanged;

            OnWindowEnable(false);
        }
        #endregion


        #region Private methods
        private void Stage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Scores"))
            {
                scoreText.text = (sender as Stage).Scores.ToString();
            }
        }
        #endregion
    }
}