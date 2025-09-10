using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WplacePaletteConverter.Extensions;

namespace WplacePaletteConverter.Views
{
	public partial class Main : Form
	{
		private Bitmap? inputImage = null;
		private Bitmap? inputImageCopy = null;
		private Bitmap? outputImage = null;
		private Models.WplaceColor[] wplaceColors; // Defined in constructor
		private ConcurrentDictionary<(uint, Enums.ComparisonMethods), Color> cache = [];
		private bool saved = true;
		private Task conversionTask = Task.CompletedTask;
		private long currentPixel = 0;
		private readonly ToolTip toolTip = new();
		private string fileName = "WPPC Untitled.png";

		public Main()
		{
			InitializeComponent();

			Enum.GetNames(typeof(Enums.ComparisonMethods))
				.ToList()
				.ForEach(method => cmbMethod.Items.Add(method));

			cmbMethod.SelectedIndex = 0; // Default to CIEDE2000

			picInput.AllowDrop = true; // Enable drag and drop for input picture box

			wplaceColors = [
				..Services.Global.WplaceFreePalette.Where(x => x.Used),
				..Services.Global.WplaceLockedPalette.Where(x => x.Used)
			];

			// Check for updates in the background
			Task.Run(() =>
			{
				bool updateAvailable;
				DialogResult dialogResult = DialogResult.None;

				try { updateAvailable = Services.AutoUpdater.CheckForUpdates(); }
				catch { updateAvailable = false; }

				if (!updateAvailable)
					return;

				Invoke(() =>
					dialogResult = MessageBox.Show("A new version is available!\nDo you want to update it now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
				);

				if (dialogResult != DialogResult.Yes)
					return;

				try { Services.AutoUpdater.Download(); }
				catch (Exception ex)
				{
					Invoke(() => MessageBox.Show("Failed to download the update.\n" + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error));
					return;
				}

				while (!conversionTask.IsCompleted)
					Thread.Sleep(100);

				try { Services.AutoUpdater.Update(); }
				catch (Exception ex)
				{
					Invoke(() => MessageBox.Show("Failed to start the updater.\n" + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error));
					return;
				}

				saved = true;
				Invoke(() => Close());
			});
		}

		private void DoConversion()
		{
			if (inputImage == null)
				return;

			outputImage = new(inputImage);
			long totalPixels = outputImage.Width * outputImage.Height;
			Enums.ComparisonMethods method = Enums.ComparisonMethods.CIEDE2000;
			Invoke(() => method = (Enums.ComparisonMethods)cmbMethod.SelectedIndex);
			Task.Run(() => LoadingUpdater(totalPixels));

			BitmapData data = outputImage.LockBits(
				new(0, 0, outputImage.Width, outputImage.Height),
				ImageLockMode.ReadWrite,
				PixelFormat.Format32bppArgb);

			unsafe
			{
				byte* ptr = (byte*)data.Scan0;

				Parallel.For(0, data.Height, y =>
				{
					byte* row = ptr + (y * data.Stride);
					for (int x = 0; x < data.Width; x++)
					{
						Interlocked.Increment(ref currentPixel);

						int index = x * 4;
						byte b = row[index];
						byte g = row[index + 1];
						byte r = row[index + 2];
						byte a = row[index + 3];

						if (a == 0)
							continue;

						Color pixel = Color.FromArgb(a, r, g, b);

						const int ARGBAlphaShift = 24;
						const int ARGBRedShift = 16;
						const int ARGBGreenShift = 8;
						const int ARGBBlueShift = 0;

						uint argbValue = (uint)a << ARGBAlphaShift |
							(uint)r << ARGBRedShift |
							(uint)g << ARGBGreenShift |
							(uint)b << ARGBBlueShift;

						// TODO:
						// One of the most expensive operations currently is checking whether
						// a color has already been cached. To improve performance, consider implementing
						// a custom cache optimized for faster lookups.
						Color closestColor = cache.TryGetValue((argbValue, method), out Color cached)
							? cached
							: (cache[(argbValue, method)] = pixel.GetMostSimilar(wplaceColors, method));

						row[index] = closestColor.B;
						row[index + 1] = closestColor.G;
						row[index + 2] = closestColor.R;
						row[index + 3] = closestColor.A;
					}
				});
			}
			outputImage.UnlockBits(data);

			Invoke(() =>
			{
				picOutput.Image = chkFitPicBoxSize.Checked ? outputImage.ResizeWithoutInterpolation(picOutput) : outputImage;
				picOutput.ResetView();
				saveAsToolStripMenuItem.Enabled = true;
			});
			saved = false;
		}

		private void EditImage()
		{
			if (inputImage == null || inputImageCopy == null)
				return;

			inputImage = inputImageCopy.ApplyContrast(trkContrast.Value / 100f);
			picInput.Image = inputImage.ResizeWithoutInterpolation(picInput);
		}

		private void LoadingUpdater(long totalPixels)
		{
			while (!conversionTask.IsCompleted)
			{
				float progress = (float)currentPixel / totalPixels * 100;
				Invoke(() => lblLoadingInfo.Text = $"Converting Pixels: {progress:N2}%...");
				Thread.Sleep(50);
			}

			Invoke(() => lblLoadingInfo.Text = "");
			currentPixel = 0;
		}

		private bool IsTaskRunning()
		{
			if (conversionTask.IsCompleted)
				return false;

			MessageBox.Show("A conversion is already in progress. Please wait for it to finish.", "Conversion In Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return true;
		}

		private void LoadNewImage(string filePath)
		{
			this.Text = "Wplace Palette Converter - " + Path.GetFileName(filePath);
			fileName = Path.GetFileNameWithoutExtension(filePath) + " WPPC.png";
			trkContrast.Value = 100;
			inputImage = new(filePath);
			inputImageCopy = new(inputImage);
			picInput.Image = inputImage.ResizeWithoutInterpolation(picInput);
			picInput.ResetView();
			lblImageSize.Text = $"{inputImage.Width}x{inputImage.Height}";
			conversionTask = Task.Run(DoConversion);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsTaskRunning())
				return;

			OpenFileDialog ofd = new();
			ofd.Filter = "PNG & JPG Image|*.png;*.jpg;*.jpeg";

			if (ofd.ShowDialog() != DialogResult.OK)
				return;

			LoadNewImage(ofd.FileName);
		}

		private void saveAsToolStripMenuItem_Click(object? sender, EventArgs? e)
		{
			if (IsTaskRunning())
				return;

			if (outputImage == null)
				return;

			SaveFileDialog sfd = new();
			sfd.Filter = "PNG Image|*.png";
			sfd.FileName = fileName;

			if (sfd.ShowDialog() != DialogResult.OK)
				return;

			outputImage.Save(sfd.FileName, ImageFormat.Png);
			saved = true;
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsTaskRunning())
				return;

			inputImage?.Dispose();
			inputImage = null;
			inputImageCopy?.Dispose();
			inputImageCopy = null;
			outputImage?.Dispose();
			outputImage = null;

			picInput.Image = null;
			picOutput.Image = null;

			this.Text = "Wplace Palette Converter";
			saveAsToolStripMenuItem.Enabled = false;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsTaskRunning())
				return;

			if (saved) {
				Close();
				return;
			}

			if (MessageBox.Show("Do you want to exit without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				Close();
		}

		private void paletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsTaskRunning())
				return;

			if (new Palette().ShowDialog() != DialogResult.Yes)
				return;

			wplaceColors = [
				..Services.Global.WplaceFreePalette.Where(x => x.Used),
				..Services.Global.WplaceLockedPalette.Where(x => x.Used)
			];

			Services.Settings.WplaceFreePalette = Services.Global.WplaceFreePalette.Copy();
			Services.Settings.WplaceLockedPalette = Services.Global.WplaceLockedPalette.Copy();
			Services.Settings.Save();

			cache.Clear();
			conversionTask = Task.Run(DoConversion);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => new About().ShowDialog();

		private void trkContrast_ValueChanged(object sender, EventArgs e)
		{
			if (IsTaskRunning())
				return;

			if (inputImage == null || inputImageCopy == null)
				return;

			lblContrast.Text = (trkContrast.Value - 100).ToString();

			inputImage = inputImageCopy.ApplySaturation(trkSaturation.Value / 100f);
			inputImage = inputImage.ApplyContrast(trkContrast.Value / 100f);
			picInput.Image = inputImage.ResizeWithoutInterpolation(picInput);
		}

		private void trkContrast_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				trkContrast.Value = 100;

			if (IsTaskRunning())
				return;

			if (inputImage == null || inputImageCopy == null)
				return;

			conversionTask = Task.Run(DoConversion);
		}

		private void trkSaturation_ValueChanged(object sender, EventArgs e)
		{
			if (IsTaskRunning())
				return;

			if (inputImage == null || inputImageCopy == null)
				return;

			lblSaturation.Text = (trkSaturation.Value - 100).ToString();

			inputImage = inputImageCopy.ApplyContrast(trkContrast.Value / 100f);
			inputImage = inputImage.ApplySaturation(trkSaturation.Value / 100f);
			picInput.Image = inputImage.ResizeWithoutInterpolation(picInput);
		}

		private void trkSaturation_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				trkSaturation.Value = 100;

			if (IsTaskRunning())
				return;

			if (inputImage == null || inputImageCopy == null)
				return;

			conversionTask = Task.Run(DoConversion);
		}

		private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!conversionTask.IsCompleted)
				return;

			conversionTask = Task.Run(DoConversion);
		}

		private void chkFitPicBoxSize_CheckedChanged(object sender, EventArgs e)
		{
			if (outputImage == null || !conversionTask.IsCompleted)
				return;

			picOutput.Image = chkFitPicBoxSize.Checked ? outputImage.ResizeWithoutInterpolation(picOutput) : outputImage;

			picOutput.ResetView();
		}

		private void chkFitPicBoxSize_MouseHover(object sender, EventArgs e)
		{
			toolTip.AutoPopDelay = 30000;
			toolTip.SetToolTip(chkFitPicBoxSize,
				"Resize the output image to the PictureBox size.\n" +
				"So what you see might not be pixel-perfect, especially for large images.\n\n" +
				"Uncheck to display the original image size.");
		}

		private void picInput_DragDrop(object sender, DragEventArgs e)
		{
			if (IsTaskRunning())
				return;

			string[] files = (string[]?)e.Data?.GetData(DataFormats.FileDrop) ?? [];

			if (files.Length == 0 ||
				(!files[0].EndsWith(".png", true, null) &&
				!files[0].EndsWith(".jpg", true, null) &&
				!files[0].EndsWith(".jpeg", true, null)))
				return;

			LoadNewImage(files[0]);
		}

		private void picInput_DragEnter(object sender, DragEventArgs e)
		{
			string[] files = (string[]?)e.Data?.GetData(DataFormats.FileDrop) ?? [];

			if (files.Length == 0 ||
				(!files[0].EndsWith(".png", true, null) &&
				!files[0].EndsWith(".jpg", true, null) &&
				!files[0].EndsWith(".jpeg", true, null)))
			{ e.Effect = DragDropEffects.None; return; }

			e.Effect = DragDropEffects.Copy;
		}

		private void picOutput_MouseMove(object sender, MouseEventArgs e)
		{
			Point coord = picOutput.GetPixelCoordinates(e.Location);
			Color color = picOutput.GetPixel(e.Location);

			if (color.IsEmpty)
			{
				lblWplaceColorName.Text = "";
				lblWplaceColor.BackColor = Color.Transparent;
				return;
			}

			Models.WplaceColor? wpColor = wplaceColors.FirstOrDefault(x => x.Color.ToArgb() == color.ToArgb());

			if (wpColor == null)
			{
				lblWplaceColorName.Text = "";
				lblWplaceColor.BackColor = Color.Transparent;
				return;
			}

			lblWplaceColorName.Text = $"{wpColor.Name} [{coord.X}x{coord.Y}]";
			lblWplaceColor.BackColor = wpColor.Color;
		}

		private void Main_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsTaskRunning())
			{
				e.Cancel = true;
				return;
			}

			if (!saved && MessageBox.Show("Do you want to exit without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
				e.Cancel = true;
		}
	}
}
