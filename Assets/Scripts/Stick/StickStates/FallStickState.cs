using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.StickState
{
    public class FallStickState : IStickState
    {
        #region Fields
        private const float TARGET_ROTATION = -90;
        private const string SOUND_FALL_PATH = "Sounds/knock";
        #endregion

        #region IStickState
        public IEnumerator DoStateAction(Stick stick)
        {
            float startRotation = stick.transform.localRotation.eulerAngles.y;
            float startTime = Time.realtimeSinceStartup;
            float fraction = 0f;

            while (fraction < 1f)
            {
                fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / stick.parameters.FallTime);

                stick.transform.rotation = Quaternion.Euler(
                    stick.transform.rotation.eulerAngles.x,
                    stick.transform.rotation.eulerAngles.y,
                    Mathf.Lerp(startRotation, TARGET_ROTATION, fraction));

                yield return null;
            }

            SoundsHandler.Instance.Play(Resources.Load<AudioClip>(SOUND_FALL_PATH));
        }


        public void Handle(Stick stick)
        {
        } 
        #endregion
    }
}
