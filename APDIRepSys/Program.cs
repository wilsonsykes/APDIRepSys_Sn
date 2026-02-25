using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using APDIRepSys.STRptForm;

namespace APDIRepSys
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 🔹 Ensure the application can find missing assemblies
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyName = new AssemblyName(args.Name).Name + ".dll";
                string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName);

                if (File.Exists(assemblyPath))
                {
                    return Assembly.LoadFile(assemblyPath);
                }
                return null;
            };

            // 🔹 Initialize application settings (DPI, fonts, etc.)
            ApplicationConfiguration.Initialize();

            // 🔹 Show SplashScreen first
            using (var splash = new SplashScreen())
            {
                splash.ShowDialog(); // blocks until the splash screen closes
            }

            // 🔹 Then launch MainForm
            Application.Run(new MainForm());

            // 🔸 Optional: Additional form after MainForm (if needed later)
            // SysSTRpt2 formsysstrpt2 = new SysSTRpt2();
            // formsysstrpt2.Load += (sender, e) => formsysstrpt2.LoadImageColumn();
            // Application.Run(formsysstrpt2);
        }
    }
}
