using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class EndGameScreen : Screen
    {
        #region Fields
        [SerializeField]
        private Text stageScore;
        [SerializeField]
        private Text bestScore;
        #endregion


        #region Unity lifecycle
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
        #endregion
    }
}