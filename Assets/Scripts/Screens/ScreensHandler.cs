using System.Linq;
using UnityEngine;

public class ScreensHandler : MonoBehaviour
{
    private static ScreensHandler instance;
    public static ScreensHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScreensHandler>();

                if (instance == null)
                {
                    instance = new GameObject("ScreensHandler").AddComponent<ScreensHandler>();
                }
            }

            return instance;
        }
    }

    [SerializeField]
    private Screen[] Screens;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Screen.OnWindowEnableEvent += Screen_OnWindowEnableEvent;  
    }


    private void Screen_OnWindowEnableEvent(bool flag, Screen screen)
    {
        if (flag)
        {
            foreach (var item in Screens)
            {
                if (item != screen)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}
