using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screens
{
    public class MainScreen : Screen
    {
        #region Unity lifecycle
        protected override void OnEnable()
        {
            OnWindowEnable(true);
        }


        protected override void OnDisable()
        {
            OnWindowEnable(false);
        }
        #endregion Unity lifecycle
    }
}
