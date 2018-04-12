using System.Linq;
using UnityEngine;

public class ScreensHandler : MonoBehaviour
{
    #region Properties
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
    #endregion


    #region Fields
    [SerializeField]
    private Screens.Screen[] GameScreens;
    #endregion


    #region Unity lifecycle
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Screens.Screen.OnWindowEnableEvent += Screen_OnWindowEnableEvent;
    }
    #endregion


    #region Event handlers
    private void Screen_OnWindowEnableEvent(bool flag, Screens.Screen screen)
    {
        if (flag)
        {
            foreach (var item in GameScreens)
            {
                if (item != screen)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    } 
    #endregion
}
