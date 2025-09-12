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
    public partial class Palette : Form
    {
        private Models.WplaceColor[] wplaceColors;

        public Palette()
        {
            InitializeComponent();

            dgvColors.Columns.AddRange(new DataGridViewTextBoxColumn[] {
                new() { Name = "Color" },
                new() { Name = "Name" },
                new() { Name = "Type" }
            });
            dgvColors.Columns.AddRange(new DataGridViewImageColumn[] {
                new() { Name = "Sel.", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells }
            });
            dgvColors.AutoGenerateColumns = false;
            dgvColors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbSelections.Items.AddRange([
                "Select...",
                "Free Colors",
                "Locked Colors",
                "Select All",
                "Deselect All"
            ]);
            cmbSelections.SelectedIndex = 0; // Default to "Select..."

            wplaceColors = [
                ..Services.Global.WplaceFreePalette.Copy(),
                ..Services.Global.WplaceLockedPalette.Copy()
            ];

            FillDgv(wplaceColors);
        }

        private void FillDgv(Models.WplaceColor[] array)
        {
            dgvColors.SuspendLayout();

            int colorColumnIndex = dgvColors.Columns["Color"].Index;
            int typeColumnIndex = dgvColors.Columns["Type"].Index;
            Bitmap iconChecked = Properties.Resources.checked_box.ResizeForDGV(dgvColors);
            Bitmap iconUnchecked = Properties.Resources.unchecked_box.ResizeForDGV(dgvColors);

            DataGridViewRow[] rows = new DataGridViewRow[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                rows[i] = new();
                rows[i].CreateCells(dgvColors,
                    "",
                    array[i].Name,
                    array[i].Type.ToString(),
                    array[i].Used ? iconChecked : iconUnchecked
                );

                rows[i].Cells[colorColumnIndex].Style.BackColor = array[i].Color;
                if (array[i].Type == Enums.WplaceColorType.Locked)
                    rows[i].Cells[typeColumnIndex].Style.ForeColor = Color.Goldenrod;
            }

            dgvColors.Rows.AddRange(rows);
            dgvColors.ResumeLayout();
        }

        private void cmbSelections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelections.SelectedIndex == 0)
                return;

            Bitmap iconChecked = Properties.Resources.checked_box.ResizeForDGV(dgvColors);
            Bitmap iconUnchecked = Properties.Resources.unchecked_box.ResizeForDGV(dgvColors);
            bool selectFree = cmbSelections.SelectedIndex == 1;
            bool selectLocked = cmbSelections.SelectedIndex == 2;
            bool selectAll = cmbSelections.SelectedIndex == 3;
            bool deselectAll = cmbSelections.SelectedIndex == 4;

            foreach (DataGridViewRow row in dgvColors.Rows)
            {
                Models.WplaceColor wpColor = wplaceColors[row.Index];

                if (selectFree && wpColor.Type != Enums.WplaceColorType.Free)
                    continue;
                if (selectLocked && wpColor.Type != Enums.WplaceColorType.Locked)
                    continue;

                wpColor.Used = selectAll || deselectAll ? selectAll : !wpColor.Used;
                row.Cells["Sel."].Value = wpColor.Used ? iconChecked : iconUnchecked;
            }

            cmbSelections.SelectedIndex = 0; // Reset to "Select..."
        }

        private void dgvColors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex != dgvColors.Columns["Sel."].Index)
                return;

            DataGridViewRow row = dgvColors.Rows[e.RowIndex];
            Models.WplaceColor wpColor = wplaceColors[e.RowIndex];
            Bitmap iconChecked = Properties.Resources.checked_box.ResizeForDGV(dgvColors);
            Bitmap iconUnchecked = Properties.Resources.unchecked_box.ResizeForDGV(dgvColors);

            wpColor.Used = !wpColor.Used;
            row.Cells["Sel."].Value = wpColor.Used ? iconChecked : iconUnchecked;
        }

        private void dgvColors_SelectionChanged(object sender, EventArgs e)
        {
            dgvColors.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Services.Global.WplaceFreePalette = [.. wplaceColors.Where(x => x.Type == Enums.WplaceColorType.Free)];
            Services.Global.WplaceLockedPalette = [.. wplaceColors.Where(x => x.Type == Enums.WplaceColorType.Locked)];

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void Palette_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}
