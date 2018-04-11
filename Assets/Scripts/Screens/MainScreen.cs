using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainScreen : Screen
{
    protected override void OnEnable()
    {
        OnWindowEnable(true);
    }


    protected override void OnDisable()
    {
        OnWindowEnable(false);
    }
}
