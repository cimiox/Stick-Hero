using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonHandler : MonoBehaviour
{
    private void Awake()
    {
        SoundsHandler.Instance.PropertyChanged += Instance_PropertyChanged;

        GetComponentInChildren<Text>().text = string.Format("Sounds {0}", SoundsHandler.Instance.IsMute ? "off" : "on");
    }

    private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("IsMute"))
        {
            GetComponentInChildren<Text>().text = string.Format("Sounds {0}", (sender as SoundsHandler).IsMute ? "off" : "on");
        }
    }

}
