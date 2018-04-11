using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsHandler : MonoBehaviour, INotifyPropertyChanged
{
    private static SoundsHandler instance;
    public static SoundsHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundsHandler>();

                if (instance == null)
                {
                    instance = new GameObject("SoundsHandler").AddComponent<SoundsHandler>();
                }
            }

            return instance;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;


    public AudioSource AudioSource { get; set; }

    public bool IsMute
    {
        get { return System.Convert.ToBoolean(PlayerPrefs.GetInt("IsMute", 0)); }
        set
        {
            PlayerPrefs.SetInt("IsMute", System.Convert.ToInt32(value));

            if (AudioSource != null)
            {
                AudioSource.enabled = value;
            }

            OnPropertyChanged("IsMute");
        }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        AudioSource = GetComponent<AudioSource>();
        AudioSource.enabled = IsMute;
    }


    public void ChangeSoundState()
    {
        IsMute = !IsMute;
    }


    public void Play(AudioClip sound)
    {
        AudioSource.clip = sound;
        AudioSource.Play();
    }


    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
