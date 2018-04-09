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

                if (instance == null)
                {
                    instance = new GameObject("GameHandler").AddComponent<GameHandler>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
