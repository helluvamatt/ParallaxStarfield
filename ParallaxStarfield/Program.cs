using Mono.Options;
using ParallaxStarfield.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallaxStarfield
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var m = Mode.Config;
            long handle = 0;
            var p = new OptionSet()
                .Add<long>("C:", o => { m = Mode.Config; handle = o; })
                .Add<long>("P=", o => { m = Mode.Preview; handle = o; })
                .Add("S", o => { m = Mode.Screensaver; });
            var extras = p.Parse(args);

            var productName = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;
            var vendorName = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            var provider = new RegistrySettingsProvider();
            provider.ApplicationName = productName;
            provider.ApplicationVendorName = vendorName;
            Settings.Default.Providers.Add(provider);
            foreach (SettingsProperty prop in Settings.Default.Properties)
            {
                prop.Provider = provider;
            }
            Settings.Default.Reload();

            switch (m)
            {
                case Mode.Screensaver:
                    foreach (Screen screen in Screen.AllScreens)
                    {
                        frmScreensaver ssForm = new frmScreensaver(screen.Bounds);
                        ssForm.Show();
                    }
                    Application.Run();
                    break;
                case Mode.Preview:
                    Application.Run(new frmScreensaver(new IntPtr(handle)));
                    break;
                case Mode.Config:
                default:
                    Application.Run(new frmConfig(new IntPtr(handle)));
                    break;
            }
        }
    }
}
