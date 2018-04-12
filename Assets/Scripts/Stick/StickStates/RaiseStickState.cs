using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.StickState
{
    public class RaiseStickState : IStickState
    {
        #region Fields
        private const string SOUND_FALL_PATH = "Sounds/beat"; 
        #endregion

        #region IStickState
        public IEnumerator DoStateAction(Stick stick)
        {
            while (true)
            {
                stick.transform.localScale = new Vector2(
                    stick.transform.localScale.x,
                    stick.transform.localScale.y + stick.parameters.RaiseSpeed * Time.fixedDeltaTime);

                if (!SoundsHandler.Instance.AudioSource.isPlaying)
                {
                    SoundsHandler.Instance.Play(Resources.Load<AudioClip>(SOUND_FALL_PATH));
                }

                yield return new WaitForFixedUpdate();
            }
        }


        public void Handle(Stick stick)
        {
            stick.State = new FallStickState();
        } 
        #endregion
    }
}
