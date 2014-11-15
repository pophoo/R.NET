using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using RDotNet;
using RDotNet.NativeLibrary;

namespace WpfApplication1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            REngine engine = REngine.GetInstance();
            if (engine != null)
            {
                engine.Close();
            }
        }
    }

}
