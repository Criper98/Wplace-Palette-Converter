using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WplacePaletteConverter
{
    internal static class Program
    {
        static readonly Mutex mutex = new(true, "Wplace Palette Converter");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("The application is already running.", "Wplace Palette Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Services.Settings.Read();

            // Manually sync settings to global (in case of messed up settings file)
            for (int i = 0; i < Services.Global.WplaceFreePalette.Length; i++)
            {
                Models.WplaceColor? wpc = Services.Settings.WplaceFreePalette.FirstOrDefault(x => x.Color.ToArgb() == Services.Global.WplaceFreePalette[i].Color.ToArgb());
                if (wpc != null)
                    Services.Global.WplaceFreePalette[i] = wpc.Clone();
            }
            for (int i = 0; i < Services.Global.WplaceLockedPalette.Length; i++)
            {
                Models.WplaceColor? wpc = Services.Settings.WplaceLockedPalette.FirstOrDefault(x => x.Color.ToArgb() == Services.Global.WplaceLockedPalette[i].Color.ToArgb());
                if (wpc != null)
                    Services.Global.WplaceLockedPalette[i] = wpc.Clone();
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Views.Main());
        }
    }
}