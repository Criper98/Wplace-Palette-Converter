using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WplacePaletteConverter.Services
{
    internal static class Global
    {
        public static string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory; // With trailing slash

        public static Models.WplaceColor[] WplaceFreePalette = [
            new(Color.FromArgb(0, 0, 0),        "Black", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(60, 60, 60),     "Dark Gray", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(120, 120, 120),  "Gray", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(210, 210, 210),  "Light Gray", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(255, 255, 255),  "White", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(96, 0, 24),      "Deep Red", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(237, 28, 36),    "Red", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(255, 127, 39),   "Orange", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(246, 170, 9),    "Gold", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(249, 221, 59),   "Yellow", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(255, 250, 188),  "Light Yellow", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(14, 185, 104),   "Dark Green", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(19, 230, 123),   "Green", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(135, 255, 94),   "Light Green", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(12, 129, 110),   "Dark Teal", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(16, 174, 166),   "Teal", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(19, 225, 190),   "Light Teal", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(40, 80, 158),    "Dark Blue", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(64, 147, 228),   "Blue", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(96, 247, 242),   "Cyan", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(107, 80, 246),   "Indigo", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(153, 177, 251),  "Light Indigo", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(120, 12, 153),   "Dark Purple", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(170, 56, 185),   "Purple", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(224, 159, 249),  "Light Purple", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(203, 0, 122),    "Dark Pink", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(236, 31, 128),   "Pink", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(243, 141, 169),  "Light Pink", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(104, 70, 52),    "Dark Brown", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(149, 104, 42),   "Brown", Enums.WplaceColorType.Free, true),
            new(Color.FromArgb(248, 178, 119),  "Beige", Enums.WplaceColorType.Free, true)
        ];

        public static Models.WplaceColor[] WplaceLockedPalette = [
            new(Color.FromArgb(170, 170, 170),  "Medium Gray", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(165, 14, 30),    "Dark Red", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(250, 128, 114),  "Light Red", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(228, 92, 26),    "Dark Orange", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(156, 132, 49),   "Dark Goldenrod", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(196, 173, 49),   "Goldenrod", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(232, 212, 95),   "Light Goldenrod", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(74, 107, 58),    "Dark Olive", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(90, 148, 74),    "Olive", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(132, 197, 115),  "Light Olive", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(15, 121, 159),   "Dark Cyan", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(187, 250, 242),  "Light Cyan", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(125, 199, 255),  "Light Blue", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(77, 49, 184),    "Dark Indigo", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(74, 66, 132),    "Dark Slate Blue", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(122, 113, 196),  "Slate Blue", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(181, 174, 241),  "Light Slate Blue", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(155, 82, 73),    "Dark Peach", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(209, 128, 120),  "Peach", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(250, 182, 164),  "Light Peach", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(219, 164, 99),   "Light Brown", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(123, 99, 82),    "Dark Tan", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(156, 132, 107),  "Tan", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(214, 181, 148),  "Light Tan", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(209, 128, 81),   "Dark Beige", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(255, 197, 165),  "Light Beige", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(109, 100, 63),   "Dark Stone", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(148, 140, 107),  "Stone", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(205, 197, 158),  "Light Stone", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(51, 57, 65),     "Dark Slate", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(109, 117, 141),  "Slate", Enums.WplaceColorType.Locked, false),
            new(Color.FromArgb(179, 185, 209),  "Light Slate", Enums.WplaceColorType.Locked, false)
        ];
    }
}
