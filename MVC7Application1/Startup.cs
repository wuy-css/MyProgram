using System;
using Ay.MvcFramework;
using MVC7Application1.Views;

namespace MVC7Application1
{
    public class Startup
    {
        [STAThread]
        static void Main()
        {

            new AYUIApplication<_ViewStart>(new Global(), true).Run();

        }

    }
}
