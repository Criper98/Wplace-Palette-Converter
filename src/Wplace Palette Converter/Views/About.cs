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

		private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(
				new System.Diagnostics.ProcessStartInfo("https://github.com/Criper98/Wplace-Palette-Converter")
				{ UseShellExecute = true }
			);
		}

		private void lnkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(
				new System.Diagnostics.ProcessStartInfo("https://raw.githubusercontent.com/Criper98/Wplace-Palette-Converter/refs/heads/main/LICENSE")
				{ UseShellExecute = true }
			);
		}

		private void lnkNewtonsoftJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(
				new System.Diagnostics.ProcessStartInfo("https://raw.githubusercontent.com/JamesNK/Newtonsoft.Json/refs/heads/master/LICENSE.md")
				{ UseShellExecute = true }
			);
		}

		private void lnkColourful_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(
				new System.Diagnostics.ProcessStartInfo("https://raw.githubusercontent.com/tompazourek/Colourful/refs/heads/master/LICENSE")
				{ UseShellExecute = true }
			);
		}
	}
}
