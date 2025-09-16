using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WplacePaletteConverter.Extensions;

namespace WplacePaletteConverter.Views
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            lblVersion.Text = $"v{Application.ProductVersion}";
        }

        private void OpenSite(string url)
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo(url)
                { UseShellExecute = true }
            );
        }

        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSite("https://github.com/Criper98/Wplace-Palette-Converter");
        }

        private void lnkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSite("https://raw.githubusercontent.com/Criper98/Wplace-Palette-Converter/refs/heads/main/LICENSE");
        }

        private void lnkFlameHorizon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSite("https://github.com/FlameHorizon");
        }

        private void lnkNewtonsoftJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSite("https://raw.githubusercontent.com/JamesNK/Newtonsoft.Json/refs/heads/master/LICENSE.md");
        }

        private void lnkColourful_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSite("https://raw.githubusercontent.com/tompazourek/Colourful/refs/heads/master/LICENSE");
        }
    }
}
